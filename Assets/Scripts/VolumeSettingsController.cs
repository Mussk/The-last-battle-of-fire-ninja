using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class VolumeSettingsController : BaseController<SettingsData>, IDataPersistence<SettingsData>
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


    void Awake() 
    {

        masterVolumeSlider.onValueChanged.AddListener(delegate { ChangeSliderText(masterVolumeText, masterVolumeSlider.value); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { ChangeSliderText(musicVolumeText, musicVolumeSlider.value); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { ChangeSliderText(sfxVolumeText, sfxVolumeSlider.value); });

        masterVolumeSlider.onValueChanged.AddListener(delegate { ChangeVolumeBySlider("MasterVolume", masterVolumeSlider.value); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { ChangeVolumeBySlider("MusicVolume", musicVolumeSlider.value); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { ChangeVolumeBySlider("SFXVolume", sfxVolumeSlider.value); });


    }

    // Start is called before the first frame update
    void Start()
    {
        

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void LoadData(SettingsData data)
    {
        if (data is not null) 
        {
            Debug.Log("Hi from: " + this.GetType().Name.ToString() + ": " + "LoadData()");
            Debug.Log("data.MasterVolumeValue: " + data.MasterVolumeValue);

            masterVolumeSlider.value = data.MasterVolumeValue;
            musicVolumeSlider.value = data.MusicVolumeValue;
            sfxVolumeSlider.value = data.SFXVolumeValue;


            ChangeVolumeBySlider("MasterVolume", masterVolumeSlider.value);
            ChangeSliderText(masterVolumeText, masterVolumeSlider.value);

            ChangeVolumeBySlider("MusicVolume", musicVolumeSlider.value);
            ChangeSliderText(musicVolumeText, musicVolumeSlider.value);

            ChangeVolumeBySlider("SFXVolume", sfxVolumeSlider.value);
            ChangeSliderText(sfxVolumeText, sfxVolumeSlider.value);


        }
    }

    public override void SaveData(ref SettingsData dataToSave)
    {
        Debug.Log("Hi from: " + this.GetType().Name.ToString());

        dataToSave.MasterVolumeValue = masterVolumeSlider.value;
        dataToSave.MusicVolumeValue = musicVolumeSlider.value;
        dataToSave.SFXVolumeValue = sfxVolumeSlider.value;
   
    }

    private void ChangeSliderText(TextMeshProUGUI textComponent, float sliderValue)
    {
        
        textComponent.text = sliderValue.ToString("0%");
    
    }

    private void ChangeVolumeBySlider(string channelName, float sliderValue)
    {

        audioMixer.SetFloat(channelName, Mathf.Log(sliderValue) * 20);

    }

    public override void InitDefaultData()
    {

        ChangeVolumeBySlider("MasterVolume", 1);
        ChangeVolumeBySlider("MusicVolume", 1);
        ChangeVolumeBySlider("SFXVolume", 1);

       
    }
}
