using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingsController : MonoBehaviour, IUIWindow, IDataPersistence
{

    [field: SerializeField]
    public GameObject UIWindowObject { get; set; }

    [field: SerializeField]
    public Volume UIBlur { get; set; }


    [SerializeField]
    private VolumeSettingsController volumeSettingsController;

    public void LoadData(SerializedData data)
    {
        if(data is not null)
        {
            throw new System.NotImplementedException();
        }
    }

    public void SaveData(ref SerializedData data)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
