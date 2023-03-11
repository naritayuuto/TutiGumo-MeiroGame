using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGM
{
    None = -1,
    Title,
    Stage,
    Goal,
    Dead,
    playerPerception,
    PlayerFind
}
public enum SE
{
    None = -1,
    Item,
    Butten
}
public class MusicManager : MonoBehaviour
{
    public static MusicManager _instance = default;

    [SerializeField]
    private AudioSource _SE;
    [SerializeField]
    private AudioSource _BGM;
    [SerializeField, Header("獲得、ボタン")]
    private AudioClip[] SEClips;
    [SerializeField, Header("タイトル、ステージ、クリア、死、察知、発見")]
    private AudioClip[] BGMClips;

    BGM _bgm = BGM.Title;
    SE _se = SE.None;
    public BGM Bgm { get => _bgm; set => _bgm = value; }
    public SE Se { get => _se; set => _se = value; }

    public static MusicManager Instance { get => _instance; }
    // Start is called before the first frame update

    public void PlaySE(SE se)
    {
        if (se != SE.None)
        {
            _se = se;
            _SE.clip = SEClips[(int)se];
            _SE.Play();
        }
    }
    public void PlaySE(int num)
    {
        SE se = (SE)num;
        if (se != SE.None)
        {
            _se = se;
            _SE.clip = SEClips[(int)se];
            _SE.Play();
        }
    }
    public void PlayBGM(BGM bgm)
    {
        if (bgm != BGM.None)
        {
            _bgm = bgm;
            _BGM.clip = BGMClips[(int)bgm];
            _BGM.Play();
        }
    }
}
