﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoisonDead : MonoBehaviour
{
    [SerializeField]
    SceneLoader _sceneLoader = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Destroy(other.gameObject);
            //プレイヤーのアニメーションを流す
            
        }
    }
}
