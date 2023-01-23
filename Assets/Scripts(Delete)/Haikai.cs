using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Haikai : MonoBehaviour
{
    /// <summary>目標との間隔、余裕を持った値にする</summary>
    [SerializeField] float dis = 5f;
    public Vector3[] points = new Vector3[3];//徘徊する場所の座標を代入する,xyzの順。
    private int coordinate;//徘徊する場所の座標
    private int mode;//spider_prefの行動パターン
    public Transform player;//プレイヤーの位置
    public Transform enemypos;//今回はspider_prefの位置
    private NavMeshAgent agent;
    Animator anim = default;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 pos = points[coordinate];//Vector3型のposに現在の目的地の座標を代入
        if (!player)
        {
            float distance = Vector3.Distance(enemypos.position, player.position);//敵とプレイヤーの距離を求める
            if (distance > dis)
            {
                mode = 0;
            }

            if (distance < dis)
            {
                mode = 1;
            }

        }
        switch (mode)
        {

            case 0:

                if (Vector3.Distance(enemypos.position, pos) < 5f)//もし敵の位置と現在の目的地との距離が5以下なら
                {
                    coordinate += 1;//次の目的地へ
                    if (coordinate > points.Length - 1)//もしcurrentRootがwayPointsの要素数-1より大きいなら
                    {
                        coordinate = 0;//最初の目的地へ
                    }
                }
                agent.SetDestination(pos);
                break;

            case 1:
                if (!player)
                {
                    agent.destination = player.position;//プレイヤーに向かって進む	
                }
                break;
        }
    }
    private void LateUpdate()
    {
        if (!anim)
        {
            return;
        }
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }
}
