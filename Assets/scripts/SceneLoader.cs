using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // シーン遷移を行うために追加している
using DG.Tweening;

public class SceneLoader : MonoBehaviour//設計上ゴールの当たり判定を持つObjectに付けること
{

    [SerializeField,Header("ゲーム、ゴール、デッド、タイトルの順"),Tooltip("移動先のシーン名")] 
    string[] _sceneName;
    [SerializeField,Header("フェードにかかる時間"),Tooltip("フェードにかかる時間")]
    float _fadeSpeed = 1f;
    [Tooltip("フェードの準備が整ったらTrue")]    
    bool _isLoadStarted = false;
    [SerializeField] 
    Image _fadePanel = null;
    State _state = State.None;
    public enum State
    {
        None = -1,
        Start,
        Goal,
        Dead,
        Title
    }
    // Update is called once per frame
    void Update()
    {
        if(_isLoadStarted)
        {
            LoatSceneState(_state);
        }
    }
    public void StageLoad()
    {
        _state = State.Start;
        _isLoadStarted = true;
    }
    public void TitleLoad()
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
