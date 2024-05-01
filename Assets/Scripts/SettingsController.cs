using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingsController : BaseController<SettingsData>, IUIWindow 
{ 

    [field: SerializeField]
    public GameObject UIWindowObject { get; set; }

    [field: SerializeField]
    public Volume UIBlur { get; set; }

    
    [field: SerializeField]
    public GraphicsQualitySettingsController GraphicsQualitySettingsController {  get; set; }

    [field: SerializeField]
    public VolumeSettingsController VolumeSettingsController { get; set; }


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
