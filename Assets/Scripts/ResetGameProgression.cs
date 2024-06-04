
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

        resetSkinProgressionButton.onClick.AddListener(ResetSkinProgressionOnClick);

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
}
