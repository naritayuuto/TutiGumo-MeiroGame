using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField,Tooltip("獲得しなければならないアイテム数"),Header("獲得しなければならないアイテム数")]
    int _count = 50;
    int _maxItemCount = 0;
    MusicManager _musicM;
    [SerializeField]
    Text _scoreText;
    public int ItemCount { get => _count; set => _count = value; }

    void Start()
    {
        _musicM = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        _maxItemCount = _count;
        Setscore();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            _count -= 1;
            _musicM.Se = MusicManager.SE.Item;
            _musicM.PlaySE(_musicM.Se);
            other.gameObject.SetActive(false);
        }
        Setscore();
    }
    void Setscore()
    {
        if (_count == _maxItemCount)
        {
            _scoreText.text = string.Format("目の前の赤い球を集めよう");
        }
        else if(0 < _count && _count < _maxItemCount)//１以上100未満
        {
            _scoreText.text = string.Format("あと{0}個集めよう", _count);
        }
        else
        {
            _scoreText.text = string.Format("ミニマップを見てゴールを目指そう");
        }
    }
}
