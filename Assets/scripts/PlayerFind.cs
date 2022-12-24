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
        _musicM = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerFind = true;
            _musicM.Bgm = MusicManager.BGM.PlayerFind;
            _musicM.PlayBGM(_musicM.Bgm);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _musicM.Bgm = MusicManager.BGM.playerPerception;
            _musicM.PlayBGM(_musicM.Bgm);
        }
    }
}
