using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkinData : SerialazableData
{

    public List<string> OwnedSkinsData { get; set; }

    public SkinData()
    {   
      
        OwnedSkinsData = new List<string>();
        
    }

    
}
