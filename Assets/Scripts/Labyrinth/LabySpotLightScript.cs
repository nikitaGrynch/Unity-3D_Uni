using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabySpotLightScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    private Light _light;

    private float period = 25f;
    void Start()
    {
        _light = this.GetComponent<Light>();
        _light.intensity = 1f;
    }

    void Update()
    {
        if (LabyState.firstPersonView)
        {
            if (LabyState.isDay)
            {
                _light.intensity = 0f;
            }
            else
            {
                _light.intensity = LabyState.spotLightIntensity -= Time.deltaTime / period;
                this.transform.position = ball.transform.position;
                this.transform.forward = Camera.main.transform.forward;
                Vector2 wheel = Input.mouseScrollDelta;
                if (wheel.y != 0)
                {
                    float angle = Mathf.Clamp(_light.spotAngle + wheel.y, 20f, 70f);
                    _light.spotAngle += wheel.y;
                    if(angle != _light.spotAngle)
                    {
                        _light.spotAngle = angle;
                        _light.intensity = 1 - (angle - 50f) / 50f;
                    }
                }
            }
        }
    }
}
