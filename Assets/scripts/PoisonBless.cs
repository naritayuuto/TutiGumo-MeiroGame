﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBless : MonoBehaviour
{
    private float _count = 0;
    [SerializeField, Tooltip("プレイヤーを倒すまでにかかる秒数"), Header("プレイヤーを倒すまでにかかる秒数")]
    float _deathTime = 1.8f;
    [Tooltip("プレイヤーが当たり判定内にいる場合True")]
    bool _playerStay = false;
    [SerializeField]
    ParticleSystem _bless;
    [SerializeField]
    Transform _muzzle;
    [SerializeField]
    SceneLoader _sceneLoader;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerStay = true;
            _count += Time.deltaTime;
            _bless.Play();
            //Instantiate(_bless, _muzzle.position, transform.rotation);
            if (_count >= _deathTime)
            {
                _sceneLoader.LoadScene(SceneLoader.State.Dead);
                _bless.Stop();
                //Destroy(_bless.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _count = 0;
            _playerStay = false;
            _bless.Stop();
        }
    }
}
