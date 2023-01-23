using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioSource _SE;
    [SerializeField]
    private AudioSource _BGM;
    [SerializeField]
    private AudioSource _PlayerSource;
    [SerializeField]
    private AudioClip[] BGMClips;
    [SerializeField]
    private AudioClip[] SEClips;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public enum SE
    {
        None = -1,
        Item,
        Butten
    }

    public enum BGM
    {
        None = -1,
        Title,
        Stage,
        Danger,
        Goal,
        Dead
    }

    public void PlaySE(SE se)
    {
        int seIndex = 0;
        switch (se)
        {
            case SE.None:
                break;
            case SE.Item:
                {
                    seIndex = (int)se;
                    break;
                }
            case SE.Butten:
                {
                    seIndex = (int)se;
                    break;
                }
        }
        _SE.clip = SEClips[seIndex];
    }
    public void PlayBGM(BGM bgm)
    {
        int bgmIndex = 0;
        switch (bgm)
        {
            case BGM.None:
                break;
            case BGM.Title:
                {
                    bgmIndex = (int)bgm;
                    break;
                }
            case BGM.Stage:
                {
                    bgmIndex = (int)bgm;
                    break;
                }
            case BGM.Danger:
                {
                    bgmIndex = (int)bgm;
                    break;
                }
            case BGM.Goal:
                {
                    bgmIndex = (int)bgm;
                    break;
                }
            case BGM.Dead:
                {
                    bgmIndex = (int)bgm;
                    break;
                }
        }
        _BGM.clip = BGMClips[bgmIndex];
    }
}
