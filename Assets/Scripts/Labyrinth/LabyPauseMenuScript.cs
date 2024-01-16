using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class LabyPauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private Slider musicVolumeSlider;
    [SerializeField]
    private Slider effectsVolumeSlider;
    [SerializeField]
    private Toggle muteAllToggle;
    [SerializeField]
    private AudioMixer soundMixer;
    [SerializeField]
    private TMPro.TMP_Dropdown qualityDropdown;
    [SerializeField]
    private Slider speedSlider;
    [SerializeField]
    private TMP_Text nicknameText;
    [SerializeField]
    private TMPro.TMP_InputField nicknameInput;

    void Start()
    {

        string[] names = QualitySettings.names;
        if(names.Length == qualityDropdown.options.Count)
        {

        }
        else
        {
            qualityDropdown.options.Clear();
            for(int i = 0; i < names.Length; i++)
            {
                qualityDropdown.options.Add(
                    new TMPro.TMP_Dropdown.OptionData(names[i]));
            }
            qualityDropdown.value = QualitySettings.GetQualityLevel();
        }
        OnMusicVolumeSlider(musicVolumeSlider.value);
        OnEffectsVolumeSlider(effectsVolumeSlider.value);
        OnMuteAllToggle(muteAllToggle.isOn);
        OnSpeedSlider(speedSlider.value);
        OnNicknameTextInput(nicknameInput.text);



        if (content.activeInHierarchy)
        {
            ShowMenu();
        }
        else
        {
            HideMenu();
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (LabyState.isPaused)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }

    private void ShowMenu()
    {
        LabyState.isPaused = true;
        content.SetActive(true);
        Time.timeScale = 0f;
    }

    private void HideMenu() {
        LabyState.isPaused = false;
        content.SetActive(false);
        Time.timeScale = 1f;
    }

    // UI event listeners
    public void OnMusicVolumeSlider(float value)
    {
        // value [0..1], dB [-80..+10]
        float dB = -80f + 90f * value;
        soundMixer.SetFloat("AmbientVolume", dB);
    }
    public void OnEffectsVolumeSlider(float value)
    {
        float dB = -80f + 90f * value;
        soundMixer.SetFloat("EffectsVolume", dB);
    }
    public void OnMuteAllToggle(bool value)
    {
        soundMixer.SetFloat("MasterVolume", value ? -80f : 0f);
    }

    public void OnSpeedSlider(float value)
    {
        LabyState.ballForceFactor = (value * (600 - 200)) + 200;
    }

    public void OnNicknameTextInput(string value)
    {
        nicknameText.text = value;
    }

    public void OnUiButtonClick(int id)
    {
        switch (id)
        {
            // exit
            case 1: {
                    if (Application.isEditor)
                    {
                        UnityEditor.EditorApplication.isPlaying = false;
                    }
                    else
                    {
                        Application.Quit();
                    }
                    break;
                }
            // reset
            case 2:
                {
                    musicVolumeSlider.value = 0.5f;
                    effectsVolumeSlider.value = 0.5f;
                    muteAllToggle.isOn = false;
                    break;
                }
            // close
            case 3: { HideMenu(); break; }
            default: { Debug.LogError($"Unknown button id: '{id}'"); break; }
                
        }
    }

    public void OnQualityDropdownChanged(int value)
    {
        //Debug.Log("OnQualityDropdownChanged " + value);
        QualitySettings.SetQualityLevel(value, true);
    }
}
