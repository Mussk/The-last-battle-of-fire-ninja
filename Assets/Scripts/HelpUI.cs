using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HelpUI : MonoBehaviour, IUIWindow
{
    [field: SerializeField]
    public GameObject UIWindowObject { get; set; }

    [field: SerializeField]
    public Volume UIBlur { get; set; }

    
}
