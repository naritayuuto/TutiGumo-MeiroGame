using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // シーン遷移を行うために追加している
using DG.Tweening;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] 
    string[] scenename;
    [SerializeField]
    float fadeSpeed = 1f;
    State _state = State.None;
    /// <summary>ロード出来るかどうか</summary>
    bool isLoadStarted = false;
    [SerializeField] 
    Image fadePanel = null;
    /// <summary>何秒で色を変えるか</summary>
    Item item;
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
        player = GameObject.Find("Player");
        item = player.GetComponent<Item>();
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
            ResultSceneLoad();
        }
    }
    public void LoadScene()
    {
        isLoadStarted = true;
    }

    public void PlayerPoisonDeadLoad()
    {
        _state = State.Dead;
        LoadScene();
    }

    public void ResultSceneLoad()
    {
        _state = State.Goal;
        LoadScene();
    }

    public void GameSceneLoad()
    {
        _state = State.Start;
        LoadScene();
    }

    public void TitleSceneLoad()
    {
        _state = State.Title;
        LoadScene();
    }

    void LoatSceneState(State state)
    {
        if(state == State.None)
        {
            return;
        }
        if (fadePanel)
        {
            fadePanel.DOColor(Color.black, fadeSpeed).OnComplete(() => SceneManager.LoadScene(scenename[(int)state]));
            isLoadStarted = false;
            Debug.Log("シーン移動完了しました");
        }
        else
        {
            SceneManager.LoadScene(scenename[(int)state]);
            isLoadStarted = false;
        }
    }
}
