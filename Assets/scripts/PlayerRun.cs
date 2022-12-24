using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Rigidbody rb = default;
    Animator anim = default;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed); ;
    }
    void LateUpdate()
    {
        anim.SetFloat("Speed", 1.0f);
    }
}
