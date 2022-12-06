using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBless : MonoBehaviour
{
    [SerializeField] GameObject bless;
    [SerializeField] Transform muzzle;
    float count = 0;
    float Descount = 1.8f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            count += Time.deltaTime;
            Instantiate(bless, muzzle.position, this.transform.rotation);
            if(count >Descount)
            {
                Destroy(bless.gameObject);
            }
        }
    }
}
