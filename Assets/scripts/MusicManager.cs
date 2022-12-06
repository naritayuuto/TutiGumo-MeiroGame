using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _SE;
    [SerializeField]
    private AudioSource _BGM;
    [SerializeField]
    private AudioSource PlayerSource;
    [SerializeField]
    private AudioClip[] BGMClips;
    [SerializeField]
    private AudioClip[] SEClips;

    BGM _bgm = BGM.Title;
    SE _se = SE.None;
    public BGM Bgm { get => _bgm; set => _bgm = value; }
    public SE Se { get => _se; set => _se = value; }


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public enum BGM
    {
        Title = 0,
        Stage,
        playerPerception,
        PlayerFind,
        Goal,
        Dead
    }
    public enum SE
    {
        None =-1,
        Item,
        Butten
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
        _SE.Play();
    }
    public void PlayBGM(BGM bgm)
    {
        int bgmIndex = 0;
        switch (bgm)
        {
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
            case BGM.PlayerFind:
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
        _BGM.Play();
    }
}
