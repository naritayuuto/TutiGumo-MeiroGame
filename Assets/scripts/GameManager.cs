using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = default;

    PlayerController _player = null;

    Item _item = null;

    public static GameManager Instance { get => _instance; }
    public PlayerController Player { get => _player;}
    public Item Item { get => _item;}

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void PlayerSet(PlayerController player)
    {
        _player = player;
    }
    public void ItemSet(Item item)
    {
        _item = item;
    }
}
