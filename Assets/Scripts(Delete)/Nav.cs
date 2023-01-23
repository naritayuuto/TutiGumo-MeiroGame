using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour
{   
    /// <summary>移動先となる位置情報</summary>
    [SerializeField] Transform target = default;
    /// <summary>移動先座標を保存する変数</summary>
    Vector3 TargetPosition;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        TargetPosition = target.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(TargetPosition, target.position) > Mathf.Epsilon) // _target が移動したら
        {
            TargetPosition = target.position; // 移動先の座標を保存する
            agent.SetDestination(TargetPosition); // Navmesh Agent に目的地をセットする（Vector3 で座標を設定していることに注意。Transform でも GameObject でもなく、Vector3 で目的地を指定する）
        }
    }
}
