using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>�p�j����w�</summary>
public class WanderingSpider : MonoBehaviour
{
    [SerializeField, Tooltip("�ڕW�Ƃ̊Ԋu�A�]�T���������l�ɂ���")]
    float _dis = 5f;
    [SerializeField, Tooltip("Player���@�m�o����Ԋu�A�]�T���������l�ɂ���")]
    float _playerPerceptionDis = 5f;
    [SerializeField, Tooltip("�v���C���[��ǐՂ��鎞��")]
    float _trackingTime = 30f;
    float _countTime = 0f;
    [Tooltip("_points�̗v�f��")]
    int _pointsNumber = 0;
    [Tooltip("0 == �v���C���[�������A1 == �v���C���[����")]
    int _mode;
    [Tooltip("player����������True")]
    bool _playerPerception = false;
    GameObject _player = null;
    [SerializeField, Tooltip("�p�j����ꏊ")]
    Vector3[] _points;
    NavMeshAgent _agent;
    MusicManager _musicM;
    Animator _anim = null;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameManager.Instance.Player;
        _musicM = GameManager.Instance.MusicManager;
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = _points[_pointsNumber];
        if (_player)
        {
            float distance = Vector3.Distance(transform.position, _player.transform.position);//���g��player�̋���
            if(distance <= _playerPerceptionDis)//�v���C���[���߂��ɂ�����
            {
                _playerPerception = true;
                if (_musicM.Bgm != BGM.playerPerception && _musicM.Bgm != BGM.PlayerFind)//���̒w偂��v���C���[���@�m���Ă��Ȃ��A�����Ă��Ȃ��ꍇ
                {
                    _musicM.PlayBGM(BGM.playerPerception);//�@�m��BGM�ɐ؂�ւ�
                }
                _mode = 1;
            }
            else
            {
                if (_playerPerception)//�@�m���Ă�����
                {
                    _countTime += Time.deltaTime;
                    _mode = 1;
                    if (_countTime >= _trackingTime)
                    {
                        _countTime = 0;
                        _playerPerception = false;
                        _musicM.PlayBGM(BGM.Stage);
                        _mode = 0;
                    }

                }
                else
                {
                    _mode = 0;
                }
            }
            //if (distance > _playerFindDis)//player���������鋗�����A����������Ă�����
            //{
            //    if (_playerPerception)//player���߂��ɂ����i�@�m�j�ꍇ�ABGM���ύX����Ă���̂�
            //    {
            //        _countTime = 0;
            //        _musicM.PlayBGM(BGM.Stage);
            //        _playerPerception = false;
            //    }
            //    _mode = 0;
            //}
            //else
            //{
            //    _countTime += Time.deltaTime;
            //    if (_musicM.Bgm != MusicManager.BGM.playerPerception && _musicM.Bgm != MusicManager.BGM.PlayerFind)
            //    {
            //        _musicM.Bgm = MusicManager.BGM.playerPerception;
            //        _musicM.PlayBGM(_musicM.Bgm);
            //    }
            //    _mode = 1;
            //}
        }
        switch (_mode)
        {

            case 0:

                if (Vector3.Distance(transform.position, pos) < _dis)
                {
                    _pointsNumber++;
                    _pointsNumber = _pointsNumber % _points.Length;
                }
                _agent.SetDestination(pos);
                break;

            case 1:
                _agent.SetDestination(_player.transform.position);//�v���C���[�Ɍ������Đi��
                break;
        }
    }

    private void LateUpdate()
    {
        if (_anim)
        {
            _anim.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }
}
