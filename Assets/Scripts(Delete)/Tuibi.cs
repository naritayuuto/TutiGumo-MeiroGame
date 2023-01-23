using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Tuibi : MonoBehaviour
{
    [SerializeField] Transform player = default;
    private NavMeshAgent navMeshAgent;
    Vector3 _cachedTargetPosition;
    [SerializeField] Animator _animator = default;
    NavMeshAgent _agent = default;
    // Start is called before the first frame update
    void Start()
    {
        // NavMeshAgentを保持する
        _agent = GetComponent<NavMeshAgent>();
        _cachedTargetPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        _cachedTargetPosition = player.position; // 移動先の座標を保存する
        _agent.SetDestination(_cachedTargetPosition); // Navmesh Agent に目的地をセットする（Vector3 で座標を設定していることに注意。Transform でも GameObject でもなく、Vector3 で目的地を指定する）
   
        // m_animator がアサインされていたら Animator Controller にパラメーターを設定する
        if (_animator)
        {
            _animator.SetFloat("Speed", _agent.velocity.magnitude);
            //_animator.SetBool("isOnOffMeshLink", _agent.isOnOffMeshLink);
        }
    }
}
