using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializedData 
{

     public List<string> SkinData { get; set; }

     public SerializedData()
     {

        SkinData = new List<string>();

     }

}
