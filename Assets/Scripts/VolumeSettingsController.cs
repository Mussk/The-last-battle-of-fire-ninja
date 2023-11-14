using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class VolumeSettingsController : MonoBehaviour
{
    [SerializeField]
    private Slider masterVolumeSlider;

    [SerializeField]
    private TextMeshProUGUI masterVolumeText;

    [SerializeField]
    private Slider musicVolumeSlider;

    [SerializeField]
    private TextMeshProUGUI musicVolumeText;

    [SerializeField]
    private Slider sfxVolumeSlider;

    [SerializeField]
    private TextMeshProUGUI sfxVolumeText;
    
    [SerializeField]
    private AudioMixer audioMixer;


    // Start is called before the first frame update
    void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(delegate { ChangeSliderText(masterVolumeText, masterVolumeSlider.value); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { ChangeSliderText(musicVolumeText, musicVolumeSlider.value); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { ChangeSliderText(sfxVolumeText, sfxVolumeSlider.value); });

        masterVolumeSlider.onValueChanged.AddListener(delegate { ChangeVolumeBySlider("MasterVolume", masterVolumeSlider.value); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { ChangeVolumeBySlider("MusicVolume", musicVolumeSlider.value); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { ChangeVolumeBySlider("SFXVolume", sfxVolumeSlider.value); });

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeSliderText(TextMeshProUGUI textComponent, float sliderValue)
    {
        
        textComponent.text = sliderValue.ToString("0%");
    
    }

    private void ChangeVolumeBySlider(string channelName, float sliderValue)
    {

        audioMixer.SetFloat(channelName, Mathf.Log(sliderValue) * 20);

    }
}
