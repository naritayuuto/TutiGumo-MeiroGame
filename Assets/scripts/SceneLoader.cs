using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // シーン遷移を行うために追加している
using DG.Tweening;

public class SceneLoader : MonoBehaviour//設計上ゴールの当たり判定を持つObjectに付けること
{

    [SerializeField,Header("ゲームシーン、ゴールシーン、デッドシーン、タイトルシーン")] 
    string[] sceneName;
    [SerializeField]
    float fadeSpeed = 1f;
    State _state = State.None;
    /// <summary>ロード出来るかどうか</summary>
    bool isLoadStarted = false;
    [SerializeField] 
    Image fadePanel = null;
    /// <summary>何秒で色を変えるか</summary>
    [SerializeField]
    Item item;
    [SerializeField]
    GameObject player = null;

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
        //player = GameObject.Find("Player");
        //item = player.GetComponent<Item>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isLoadStarted)
        {
            LoatSceneState(_state);
        }
    }
    void OnTriggerEnter(Collider other)//ゴール用
    {
        if (other.CompareTag("Player") && item.ItemCount <= 0)
        {
            LoadScene(State.Goal);
        }
    }
    public void StageLoad()//GameOver用
    {
        _state = State.Start;
        isLoadStarted = true;
    }
    public void TitleLoad()//GameOver用
    {
        _state = State.Title;
        isLoadStarted = true;
    }
    public void LoadScene(State state)
    {
        _state = state;
        isLoadStarted = true;
    }

    void LoatSceneState(State state)
    {
        if(state == State.None)
        {
            return;
        }
        if (fadePanel)
        {
            fadePanel.DOColor(Color.black, fadeSpeed).OnComplete(() => SceneManager.LoadScene(sceneName[(int)state]));
            isLoadStarted = false;
            Debug.Log("シーン移動完了しました");
        }
        else
        {
            SceneManager.LoadScene(sceneName[(int)state]);
            isLoadStarted = false;
        }
    }
}
