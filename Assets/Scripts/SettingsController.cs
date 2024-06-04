using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsController : SerializableController<SettingsData>, IUIWindow 
{ 

    [field: SerializeField]
    public GameObject UIWindowObject { get; set; }

    [field: SerializeField]
    public Volume UIBlur { get; set; }

    
   // [field: SerializeField]
   // public GraphicsQualitySettingsController GraphicsQualitySettingsController {  get; set; }

  //  [field: SerializeField]
   // public VolumeSettingsController VolumeSettingsController { get; set; }


    [Header("Buttons")]

    [SerializeField]
    private Button HelpButton;

    [SerializeField]
    private GameObject HelpWindow;

    void Start() 
    {
        if(HelpButton is not null)
            HelpButton.onClick.AddListener(delegate { OpenNewWindow(HelpWindow); });
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OpenNewWindow(GameObject newWindow) 
    { 
    
        newWindow.SetActive(true);
    
    }

}
