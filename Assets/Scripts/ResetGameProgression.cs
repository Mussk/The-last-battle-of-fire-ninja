
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ResetGameProgression : MonoBehaviour
{

    [SerializeField]
    private Button resetSkinProgressionButton;

    [SerializeField]
    List<string> configFileNames;

    private void Awake()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            resetSkinProgressionButton.onClick.AddListener(ResetSkinProgressionOnClickWebGL);
        #else
            resetSkinProgressionButton.onClick.AddListener(ResetSkinProgressionOnClick);
        #endif
    }

    private void ResetSkinProgressionOnClick() 
    {
        foreach (var fileName in configFileNames) 
        {

            string fullPath = Path.Combine(Application.persistentDataPath, fileName);
     
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            
        }

        CoinsManager.CoinsAmountOverall = 0;
        
    }

    private void ResetSkinProgressionOnClickWebGL()
    {
        foreach (var fileName in configFileNames)
        {
            WebGLStorage.Erase(fileName);

        }

        CoinsManager.CoinsAmountOverall = 0;

    }
}
