using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBless : MonoBehaviour
{
    [SerializeField] GameObject bless;
    [SerializeField] Transform muzzle;
    [SerializeField] SceneLoader _sceneLoader;
    float count = 0;
    [Tooltip("")]
    float deathTime = 1.8f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //count += Time.deltaTime;
            //Instantiate(bless, muzzle.position, transform.rotation);
            //if(count > deathTime)
            //{
            _sceneLoader.LoadScene(SceneLoader.State.Dead);
            //Destroy(bless.gameObject);
            //}
        }
    }
}
