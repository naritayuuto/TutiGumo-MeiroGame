using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // シーン遷移を行うために追加している
using DG.Tweening;

public class SceneLoader : MonoBehaviour//設計上ゴールの当たり判定を持つObjectに付けること
{

    [SerializeField,Header("ゲームシーン、ゴールシーン、デッドシーン、タイトルシーンの順に名前を入力"),Tooltip("移動先のシーン名")] 
    string[] _sceneName;
    [SerializeField]
    float _fadeSpeed = 1f;
    State _state = State.None;
    /// <summary>ロード出来るかどうか</summary>
    bool _isLoadStarted = false;
    [SerializeField] 
    Image _fadePanel = null;
    /// <summary>何秒で色を変えるか</summary>
    [SerializeField,Header("プレイヤーが持っている")]
    Item _item;

    public enum State
    {
        None = -1,
        Start,
        Goal,
        Dead,
        Title
    }

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(_isLoadStarted)
        {
            LoatSceneState(_state);
        }
    }
    void OnTriggerEnter(Collider other)//ゴール用
    {
        if (other.CompareTag("Player") && _item.ItemCount <= 0)
        {
            LoadScene(State.Goal);
        }
    }
    public void StageLoad()//
    {
        _state = State.Start;
        _isLoadStarted = true;
    }
    public void TitleLoad()//GameOver用
    {
        _state = State.Title;
        _isLoadStarted = true;
    }
    public void LoadScene(State state)
    {
        _state = state;
        _isLoadStarted = true;
    }

    void LoatSceneState(State state)
    {
        if(state == State.None)
        {
            return;
        }
        if (_fadePanel)
        {
            _fadePanel.DOColor(Color.black, _fadeSpeed).OnComplete(() => SceneManager.LoadScene(_sceneName[(int)state]));
            _isLoadStarted = false;
            Debug.Log("シーン移動完了しました");
        }
        else
        {
            SceneManager.LoadScene(_sceneName[(int)state]);
            _isLoadStarted = false;
        }
    }
}
