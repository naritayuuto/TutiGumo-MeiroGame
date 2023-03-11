using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField,Tooltip("プレイヤーを見下ろす時のY軸の高さ"),Header("見下ろす高さ")]
    float _posY = 0;
    [SerializeField, Tooltip("ミニマップ表示用GameObject"), Header("ミニマップを表示しているオブジェクト")]
    GameObject _miniMap = null;

    GameObject _player = null;
    Rigidbody _playerRb = null;
    private void Start()
    {
        _player = GameManager.Instance.Player;
        _playerRb = _player.GetComponent<Rigidbody>();
        _miniMap.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Item.ItemCount == 0)
        {
            _miniMap.SetActive(true);
        }
        if (!_playerRb.IsSleeping())
        {
            transform.position = new Vector3(_player.transform.position.x, _posY, _player.transform.position.z);
        }
    }
}
