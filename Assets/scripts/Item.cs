using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Item : MonoBehaviour
{
    [Tooltip("獲得しなければならないアイテム数")]
    int _maxItemCount = 0;
    [SerializeField,Tooltip("獲得しなければならないアイテム数の残り"),Header("獲得しなければならないアイテム数の残り")]
    int _itemCount = 50;
    [SerializeField]
    Text _scoreText;
    MusicManager _musicM;

    public int ItemCount { get => _itemCount; set => _itemCount = value; }

    void Start()
    {
        _musicM = GameManager.Instance.MusicManager;
        _maxItemCount = _itemCount;
        Setscore();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            _itemCount -= 1;
            _musicM.PlaySE(SE.Item);
            other.gameObject.SetActive(false);
        }
        Setscore();
    }
    void Setscore()
    {
        if (_itemCount == _maxItemCount)
        {
            _scoreText.text = string.Format("目の前の赤い球を集めよう");
        }
        else if(0 < _itemCount && _itemCount < _maxItemCount)//１以上100未満
        {
            _scoreText.text = string.Format("あと{0}個集めよう", _itemCount);
        }
        else
        {
            _scoreText.text = string.Format("ミニマップを見てゴールを目指そう");
        }
    }
}
