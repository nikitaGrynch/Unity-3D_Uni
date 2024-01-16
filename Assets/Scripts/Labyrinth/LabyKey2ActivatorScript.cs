using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyKey2ActivatorScript : MonoBehaviour
{
    void Start()
    {
        LabyState.key2Activated = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LabyState.key2Activated = true;
            GameObject.Destroy(this.gameObject);
        }
    }

}
