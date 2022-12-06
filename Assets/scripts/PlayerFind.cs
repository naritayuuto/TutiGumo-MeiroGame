using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFind : MonoBehaviour
{
    bool _playerFind = false;
    MusicManager musicM;
    public bool _PlayerFind { get => _playerFind; set => _playerFind = value; }

    private void Start()
    {
        musicM = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerFind = true;
            musicM.PlayBGM(MusicManager.BGM.PlayerFind);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicM.PlayBGM(MusicManager.BGM.playerPerception);
        }
    }
}
