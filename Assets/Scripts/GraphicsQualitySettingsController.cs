using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class GraphicsQualitySettingsController : SerializableController<SettingsData>, IDataPersistence<SettingsData>
{
    [SerializeField]
    private TMP_Dropdown graphicsQualtiyDropdown;

    [SerializeField]
    private RenderPipelineAsset[] qualityLevels;

  
    void Start()
    {
        graphicsQualtiyDropdown.onValueChanged.AddListener(ChangeGraphicsQuality);
        
    }

    public override void LoadData(SettingsData data)
    {
        ChangeGraphicsQuality(data.GraphicsQualityValue);
        graphicsQualtiyDropdown.value = QualitySettings.GetQualityLevel();
    }

    public override void SaveData(ref SettingsData dataToSave)
    {
        dataToSave.GraphicsQualityValue = graphicsQualtiyDropdown.value;
    }

    private void ChangeGraphicsQuality(int assetNumber)
    { 
    
        QualitySettings.SetQualityLevel(assetNumber);
        QualitySettings.renderPipeline = qualityLevels[assetNumber];
    
    }

    public override void InitDefaultData()
    {

        graphicsQualtiyDropdown.value = 0;
        ChangeGraphicsQuality(0);

    }
}
