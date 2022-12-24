using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>�p�j����w�</summary>
public class WanderingSpider : MonoBehaviour
{
    [SerializeField,Tooltip("�ڕW�Ƃ̊Ԋu�A�]�T���������l�ɂ���")]
    float dis = 5f;
    [SerializeField, Tooltip("Player�Ƃ̊Ԋu�A�]�T���������l�ɂ���")]
    float playerFindDis = 5f;
    [SerializeField,Tooltip("�v���C���[��ǐՂ��鎞��")]
    float trackingTime = 30f;
    float countTime = 0f;
    /// <summary>�p�j�ꏊ���܂Ƃ߂��z��̗v�f��</summary>
    int pointsNumber = 0;
    /// <summary>0 == �v���C���[�������A1 == �v���C���[����</summary>
    int mode;
    [SerializeField,Tooltip("�p�j����ꏊ")]
    Vector3[] points;
    GameObject player = null;
    NavMeshAgent agent;
    MusicManager _musicM;
    PlayerFind playerFind;
    Animator anim = default;
    [Tooltip("player����������True")]
    bool playerPerception = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        _musicM = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        playerFind = GetComponentInChildren<PlayerFind>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = points[pointsNumber];
        if (player)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > playerFindDis)
            {
                mode = playerPerception ? 1 : 0;
            }
            else
            {   
                countTime += Time.deltaTime;
                if (_musicM.Bgm != MusicManager.BGM.playerPerception && _musicM.Bgm != MusicManager.BGM.PlayerFind)
                {
                    _musicM.Bgm = MusicManager.BGM.playerPerception;
                    _musicM.PlayBGM(_musicM.Bgm);
                }
                mode = 1;
            }
        }
        switch (mode)
        {

            case 0:

                if (Vector3.Distance(transform.position, pos) < dis)
                {
                    pointsNumber++;
                    pointsNumber = pointsNumber % points.Length;
                }
                agent.SetDestination(pos);
                break;

            case 1:
                    playerPerception = true;
                    agent.destination = player.transform.position;//�v���C���[�Ɍ������Đi��
                break;
        }
    }

    public void PlayerDead()
    {
        playerPerception = false;
        player = null;
    }
}
