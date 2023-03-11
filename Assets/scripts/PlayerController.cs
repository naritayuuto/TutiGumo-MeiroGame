using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3;
    [SerializeField] float _turnSpeed = 3f;
    Rigidbody _rb = default;
    Animator _anim = null;
    /// <summary>入力された方向の XZ 平面でのベクトル</summary>
    Vector3 _dir;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力が無いときはそれまでの方向保持
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
        else
        {
            //ワールド座標へ変換
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;
            //滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _turnSpeed);

            Vector3 velo = dir.normalized * _moveSpeed; 
            velo.y = _rb.velocity.y;
            _rb.velocity = velo;   
        }
    }
    void LateUpdate()
    {
        Vector3 velocity = _rb.velocity;
        velocity.y = 0;
        _anim.SetFloat("Speed", velocity.magnitude);
    }
}