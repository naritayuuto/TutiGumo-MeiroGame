using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = default;

    [Tooltip("プレイヤーのオブジェクト")]
    GameObject _player = null;
    PlayerController _playerController = null;
    Item _item = null;
    [Tooltip("MusicManagerが付いているオブジェクト")]
    MusicManager _musicManager = null;
    [Tooltip("SceneLoaderが付いているオブジェクト")]
    SceneLoader _sceneLoader = null;

    [SerializeField,Header("タイトル、ゲーム、ゴール、デッド、の順"), Tooltip("現在のシーン名")]
    string[] _sceneName;
    public static GameManager Instance { get => _instance; }

    public GameObject Player { get => _player; }
    public PlayerController PlayerController { get => _playerController; }
    public Item Item { get => _item;}
    public MusicManager MusicManager { get => _musicManager;}

    public SceneLoader SceneLoader { get => _sceneLoader; }
    public string[] SceneName { get => _sceneName;}


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
        //迷路の自動生成で大量のオブジェクトが発生しているので、Findを使っていない
        _player = GameObject.FindGameObjectWithTag("Player");
        _musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        _sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        if (Player)
        {
            _playerController = _player.GetComponent<PlayerController>();
            _item = _player.GetComponent<Item>();
        }
    }
    private void Start()
    {
       for(int num = 0; num < _sceneName.Length; num++)
        {
            if(SceneManager.GetActiveScene().name == _sceneName[num])
            {
                _musicManager.PlayBGM((BGM)num);
                break;
            }
        }
    }
}
