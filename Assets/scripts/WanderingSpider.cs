using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>徘徊する蜘蛛</summary>
public class WanderingSpider : MonoBehaviour
{
    [SerializeField,Tooltip("目標との間隔、余裕を持った値にする")]
    float dis = 5f;
    [SerializeField, Tooltip("Playerとの間隔、余裕を持った値にする")]
    float playerFindDis = 5f;
    [SerializeField,Tooltip("プレイヤーを追跡する時間")]
    float trackingTime = 30f;
    float countTime = 0f;
    /// <summary>徘徊場所をまとめた配列の要素数</summary>
    int pointsNumber = 0;
    /// <summary>0 == プレイヤー未発見、1 == プレイヤー発見</summary>
    int mode;
    [SerializeField,Tooltip("徘徊する場所")]
    Vector3[] points;
    GameObject player = null;
    NavMeshAgent _agent;
    MusicManager _musicM;
    PlayerFind playerFind;
    Animator _anim = default;
    [Tooltip("playerを見つけたらTrue")]
    bool _playerPerception = false;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        _musicM = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        _anim = GetComponent<Animator>();
        playerFind = GetComponentInChildren<PlayerFind>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = points[pointsNumber];
        if (player)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);//自身とplayerの距離
            if (distance > playerFindDis)//playerを見つけられる距離より、距離が離れていたら
            {
                if(_playerPerception)//playerを見つけていたら
                {
                    countTime = 0;
                    _musicM.Bgm = MusicManager.BGM.Stage;
                    _musicM.PlayBGM(_musicM.Bgm);
                    _playerPerception = false;
                }
                mode = 0;
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
                _agent.SetDestination(pos);
                break;

            case 1:
                    _playerPerception = true;
                    _agent.destination = player.transform.position;//プレイヤーに向かって進む
                break;
        }
    }

    public void PlayerDead()
    {
        _playerPerception = false;
        player = null;
    }
    private void LateUpdate()
    {
        if(_anim)
        {
            _anim.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }
}
