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
    [Tooltip("入力された方向の XZ 平面でのベクトル")]
    Vector3 _dir;
    bool _playerMove = default;
    public bool PlayerMove { get => _playerMove;}

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        _dir = Vector3.forward * v + Vector3.right * h;

        if (_dir == Vector3.zero)
        {
            // 方向の入力が無いときはそれまでの方向保持
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
            _playerMove = false;
        }
        else
        {
            _playerMove = true;
            //ワールド座標へ変換
            _dir = Camera.main.transform.TransformDirection(_dir);
            _dir.y = 0;
            //滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(_dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _turnSpeed);

            Vector3 move = _dir.normalized * _moveSpeed; 
            move.y = _rb.velocity.y;
            _rb.velocity = move;
        }
    }
    void LateUpdate()
    {
        Vector3 velocity = _rb.velocity;
        velocity.y = 0;
        _anim.SetFloat("Speed", velocity.magnitude);//正規化して渡す。
    }
}