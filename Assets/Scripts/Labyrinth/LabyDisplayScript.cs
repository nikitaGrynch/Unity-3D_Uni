using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabyDisplayScript : MonoBehaviour
{
    [SerializeField]
    private Image image1;
    [SerializeField]
    private Image image2;

    private string[] observedProperties = {
        nameof(LabyState.key1Remained),
        nameof(LabyState.key2Remained)
    };

    void Start()
    {
        LabyState.AddObserver(this.OnGameStateChanged, observedProperties);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        LabyState.RemoveObserver(this.OnGameStateChanged, observedProperties);
    }

    private void OnGameStateChanged(string propertyName)
    {
        if(propertyName == nameof(LabyState.key1Remained))
        {
            image1.fillAmount = LabyState.key1Remained;
        }
        else if (propertyName == nameof(LabyState.key2Remained))
        {
            image2.fillAmount = LabyState.key2Remained;
        }
    }
}
