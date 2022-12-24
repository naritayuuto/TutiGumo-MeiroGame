using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Item : MonoBehaviour
{
    private int count = 100;
    MusicManager musicM;
    public Text scoretext;
    Text text;
    public int ItemCount { get => count; set => count = value; }

    void Start()
    {
        musicM = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        Setscore();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            ItemCount -= 1;
            musicM.Se = MusicManager.SE.Item;
            musicM.PlaySE(musicM.Se);
            Destroy(other.gameObject);
        }
        Setscore();
    }
    void Setscore()
    {
        if (ItemCount == 100)
        {
            scoretext.text = string.Format("目の前の赤い球を集めよう");
        }
        else if(0 < ItemCount && ItemCount < 100)//１以上100未満
        {
            scoretext.text = string.Format("あと{0}個集めよう", ItemCount);
        }
        else
        {
            scoretext.text = string.Format("ゴールを見つけて脱出しよう");
        }
    }
}
