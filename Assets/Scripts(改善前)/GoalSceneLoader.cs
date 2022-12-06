using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GoalSceneLoader : MonoBehaviour
{
    [SerializeField] string scenename = "ここにシーン名を入力してください";
    Item item;
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        item = player.GetComponent<Item>();
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && item.ItemCount <= 0)
        {  
            SceneManager.LoadScene(scenename); 
        }
    }
}
