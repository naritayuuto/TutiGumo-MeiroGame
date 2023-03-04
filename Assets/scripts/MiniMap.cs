using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField,Tooltip("�v���C���[�������낷����Y���̍���"),Header("�����낷����")]
    float _posY = 0;
    [SerializeField,Tooltip("�v���C���[�I�u�W�F�N�g"),Header("�v���C���[�I�u�W�F�N�g")]
    GameObject _player = null;
    [SerializeField, Tooltip("�~�j�}�b�v�\���pGameObject"), Header("�~�j�}�b�v��\�����Ă���I�u�W�F�N�g")]
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
