using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyGates1Script : MonoBehaviour
{
    private float period = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float factor = Time.deltaTime / period;
        if (!LabyState.key1Collected)
        {
            factor *= 0.02f;
        }
        Vector3 newPostition = this.transform.position + factor* Vector3.down;
        if (this.transform.position.y < -0.16f || this.transform.position.y > 0.16f)
        {
            period = -period;
            // newPostition.y = Mathf.Clamp(this.transform.position.y, -0.16f, 0.16f);
            newPostition.y = newPostition.y < -0.16f ? -0.16f : 0.16f;
        }
        this.transform.position = newPostition;
    }
}
