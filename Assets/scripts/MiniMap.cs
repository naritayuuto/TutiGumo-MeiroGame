using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField,Tooltip("�v���C���[�������낷����Y���̍���"),Header("�����낷����")]
    float _posY = 0;
    [SerializeField, Tooltip("�~�j�}�b�v�\���pGameObject"), Header("�~�j�}�b�v��\�����Ă���I�u�W�F�N�g")]
    GameObject _miniMap = null;

    GameObject _player = null;
    private void Start()
    {
        _player = GameManager.Instance.Player;
        _miniMap.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Item.ItemCount == 0)
        {
            _miniMap.SetActive(true);
        }
        if (GameManager.Instance.PlayerController.PlayerMove)
        {
            transform.position = new Vector3(_player.transform.position.x, _posY, _player.transform.position.z);
        }
    }
}
