using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>�p�j����w�</summary>
public class WanderingSpider : MonoBehaviour
{
    [SerializeField, Tooltip("�ڕW�Ƃ̊Ԋu�A�]�T���������l�ɂ���")]
    float _targetDis = 7f;
    [SerializeField, Tooltip("Player���@�m�o����Ԋu�A�]�T���������l�ɂ���")]
    float _playerPerceptionDis = 12f;
    [SerializeField, Tooltip("�v���C���[��ǐՂ��鎞��")]
    float _trackingTime = 30f;
    float _countTime = 0f;
    [Tooltip("_points�̗v�f��")]
    int _pointsNumber = 0;
    [Tooltip("0 == �v���C���[�������A1 == �v���C���[����")]
    int _mode = 0;
    [Tooltip("player����������True")]
    bool _playerPerception = false;
    GameObject _player = null;
    [SerializeField, Tooltip("�p�j����ꏊ")]
    Vector3[] _points;
    [Tooltip("�ڕW�̈ʒu")]
    Vector3 _targetPos;
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
        _targetPos = _points[_pointsNumber];
    }

    // Update is called once per frame
    void Update()
    {
        if (_player)
        {
            float distance = Vector3.Distance(transform.position, _player.transform.position);//���g��player�̋���
            if (distance <= _playerPerceptionDis)//�v���C���[���߂��ɂ�����
            {
                _countTime = 0;
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
        }
        switch (_mode)
        {
            case 0:
                if (Vector3.Distance(transform.position, _targetPos) < _targetDis)
                {
                    _pointsNumber++;
                    _pointsNumber = _pointsNumber % _points.Length;
                    _targetPos = _points[_pointsNumber];
                }
                _agent.SetDestination(_targetPos);
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
