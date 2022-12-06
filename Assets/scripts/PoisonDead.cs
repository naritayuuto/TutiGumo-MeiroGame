using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoisonDead : MonoBehaviour
{
    SceneLoader _sceneLoader = null;
    private void Start()
    {
        _sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Destroy(other.gameObject);
            //プレイヤーのアニメーションを流す
            _sceneLoader.PlayerPoisonDeadLoad();
        }
    }
}
