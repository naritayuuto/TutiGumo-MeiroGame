using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = default;

    [SerializeField,Tooltip("プレイヤーのオブジェクト"),Header("マップ上のプレイヤー")]
    GameObject _player = null;
    PlayerController _playerController = null;

    Item _item = null;
    [SerializeField,Header("MusicManagerが付いているオブジェクト")]
    MusicManager _musicManager = null;
    [SerializeField,Header("SceneLoaderが付いているオブジェクト")]
    SceneLoader _sceneLoader = null;

    public static GameManager Instance { get => _instance; }

    public GameObject Player { get => _player; }
    public PlayerController PlayerController { get => _playerController; }
    public Item Item { get => _item;}
    public MusicManager MusicManager { get => _musicManager;}

    public SceneLoader SceneLoader { get => _sceneLoader; }

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
        _playerController = _player.GetComponent<PlayerController>();
        _item = _player.GetComponent<Item>();
    }

}
