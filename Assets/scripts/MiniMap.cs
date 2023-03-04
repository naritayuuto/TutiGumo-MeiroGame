using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField,Tooltip("プレイヤーを見下ろす時のY軸の高さ"),Header("見下ろす高さ")]
    float _posY = 0;
    [SerializeField,Tooltip("プレイヤーオブジェクト"),Header("プレイヤーオブジェクト")]
    GameObject _player = null;
    [SerializeField, Tooltip("ミニマップ表示用GameObject"), Header("ミニマップを表示しているオブジェクト")]
    GameObject _miniMap = null;

    private void Start()
    {
        _miniMap.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Item.ItemCount == 0)
        {
            _miniMap.SetActive(true);
        }
        transform.position = new Vector3(_player.transform.position.x, _posY, _player.transform.position.z);
    }
}
