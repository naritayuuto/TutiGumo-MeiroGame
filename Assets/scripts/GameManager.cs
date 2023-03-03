using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = default;
    [Tooltip("プレイヤーのオブジェクト")]
    GameObject _player = null;

    PlayerController _playerController = null;

    Item _item = null;

    public static GameManager Instance { get => _instance; }

    public GameObject Player { get => _player; }
    public PlayerController PlayerController { get => _playerController; }
    public Item Item { get => _item;}

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _item = _player.GetComponent<Item>();
    }

}
