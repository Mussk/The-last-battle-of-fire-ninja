using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class GraphicsQualitySettingsController : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown graphicsQualtiyDropdown;

    [SerializeField]
    private RenderPipelineAsset[] qualityLevels;

    void Start()
    {
        graphicsQualtiyDropdown.onValueChanged.AddListener(ChangeGraphicsQuality);
    }

    // Start is called before the first frame update
    void Awake()
    {
        graphicsQualtiyDropdown.value = QualitySettings.GetQualityLevel();    
    }

    private void ChangeGraphicsQuality(int assetNumber)
    { 
    
        QualitySettings.SetQualityLevel(assetNumber);
        QualitySettings.renderPipeline = qualityLevels[assetNumber];
    
    }
}
