using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField,Tooltip("�v���C���[�������낷����Y���̍���"),Header("�����낷����")]
    float _posY = 0;
    [SerializeField,Tooltip("�v���C���[�I�u�W�F�N�g"),Header("�v���C���[�I�u�W�F�N�g")]
    GameObject _player = null;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, _posY, _player.transform.position.z);
    }
}
