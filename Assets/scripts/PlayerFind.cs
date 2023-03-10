using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFind : MonoBehaviour
{
    bool _playerFind = false;
    MusicManager _musicM;
    public bool _PlayerFind { get => _playerFind; set => _playerFind = value; }

    private void Start()
    {
        _musicM = GameManager.Instance.MusicManager;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerFind = true;
            if (_musicM.Bgm != BGM.PlayerFind)
            {
                _musicM.PlayBGM(BGM.PlayerFind);
            }
        }
    }
}
