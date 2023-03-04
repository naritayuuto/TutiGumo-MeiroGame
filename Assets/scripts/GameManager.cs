using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = default;

    [SerializeField,Tooltip("�v���C���[�̃I�u�W�F�N�g"),Header("�}�b�v��̃v���C���[")]
    GameObject _player = null;
    PlayerController _playerController = null;

    Item _item = null;
    [SerializeField,Header("MusicManager���t���Ă���I�u�W�F�N�g")]
    MusicManager _musicManager = null;
    [SerializeField,Header("SceneLoader���t���Ă���I�u�W�F�N�g")]
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
