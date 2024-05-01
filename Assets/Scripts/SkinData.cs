using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkinData : SerialazableData
{

    public string CurrentSkinMaterialName { get; set; }

    public List<string> OwnedSkinsData { get; set; }

    public SkinData()
    {   

        CurrentSkinMaterialName = string.Empty;
        OwnedSkinsData = new List<string>();
        

    }

    
}
