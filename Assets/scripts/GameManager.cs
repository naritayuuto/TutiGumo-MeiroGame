using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = default;

    [Tooltip("�v���C���[�̃I�u�W�F�N�g")]
    GameObject _player = null;
    PlayerController _playerController = null;
    Item _item = null;
    [Tooltip("MusicManager���t���Ă���I�u�W�F�N�g")]
    MusicManager _musicManager = null;
    [Tooltip("SceneLoader���t���Ă���I�u�W�F�N�g")]
    SceneLoader _sceneLoader = null;

    [SerializeField,Header("�^�C�g���A�Q�[���A�S�[���A�f�b�h�A�̏�"), Tooltip("���݂̃V�[����")]
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
        //���H�̎��������ő�ʂ̃I�u�W�F�N�g���������Ă���̂ŁAFind���g���Ă��Ȃ�
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
