using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satti : MonoBehaviour
{

    [SerializeField] private AudioSource satti;
    [SerializeField] GameObject BGM;
    private void Start()
    {
        satti = GetComponent<AudioSource>();
        if(satti == null)
        {
            satti = BGM.GetComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            satti.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            satti.Stop();
        }
    }
}
