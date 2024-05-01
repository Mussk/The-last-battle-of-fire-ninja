using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCurrentSkinData : SerialazableData
{
    public string CurrentSkinMaterialName { get; set; }


    public PlayerCurrentSkinData()
    { 
    
        CurrentSkinMaterialName = string.Empty;
    
    }
}
