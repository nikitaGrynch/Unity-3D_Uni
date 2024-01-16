using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyLightScript : MonoBehaviour
{
    private Light _light;
    private Color dayLightColor;

    private float lightIntensityStep = 0.15f;

    private bool _isDay;
    private bool isDay
    {
        get => _isDay;
        set
        {
            _isDay = LabyState.isDay = value;
            if (_isDay)
            {
                LabyState.spotLightIntensity = 1f;
                SetDayLighting();
            }
            else
            {
                SetNightLighting();
            }
        }
    }
    void Start()
    {
        _light = this.GetComponent<Light>();
        dayLightColor = _light.color;
        isDay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (LabyState.isPaused) return;
        if (Input.GetKeyUp(KeyCode.N))
        {
            isDay = !isDay;
        }
        else if (Input.GetKeyUp(KeyCode.RightBracket)){
            if (_light.intensity + lightIntensityStep <= 1.0f)
            {
                _light.intensity += lightIntensityStep;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftBracket))
        {
            if (_light.intensity - lightIntensityStep >= 0.01f)
            {
                _light.intensity -= lightIntensityStep;
            }
        }
    }

    private void SetDayLighting()
    {
        _light.intensity = 1f;
        _light.color = dayLightColor;
        RenderSettings.skybox.SetFloat("_Exposure", 1f);
    }
    private void SetNightLighting() {
        _light.intensity = .0f;
        _light.color = Color.blue;
        RenderSettings.skybox.SetFloat("_Exposure", 0.01f);
    }

    private void OnDestroy()
    {
        isDay = true;
    }

}
