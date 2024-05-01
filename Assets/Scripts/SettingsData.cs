using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData : SerialazableData
{
    public float MasterVolumeValue { get; set; }
    public float MusicVolumeValue { get; set; }
    public float SFXVolumeValue { get; set; }

    public int GraphicsQualityValue { get; set; }


    public SettingsData() 
    {
        
        MasterVolumeValue = 1;
        MusicVolumeValue = 1;
        SFXVolumeValue = 1;
        GraphicsQualityValue = 0;


    }

   
    public SettingsData(float MasterVolumeValue, float MusicVolumeValue, float SFXVolumeValue)
    {

        this.MasterVolumeValue = MasterVolumeValue;
        this.MusicVolumeValue = MusicVolumeValue;
        this.SFXVolumeValue = SFXVolumeValue;

    }
    public SettingsData(int GraphicsQualityValue)
    {

        this.GraphicsQualityValue = GraphicsQualityValue;

    }

}
