using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusicScript : MonoBehaviour
{
    private static AmbientMusicScript instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
