using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField,Tooltip("プレイヤーを見下ろす時のY軸の高さ"),Header("見下ろす高さ")]
    float _posY = 0;
    [SerializeField,Tooltip("プレイヤーオブジェクト"),Header("プレイヤーオブジェクト")]
    GameObject _player = null;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, _posY, _player.transform.position.z);
    }
}
