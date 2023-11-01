using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public interface IUIWindow 
{
    GameObject UIWindowObject { get; }
    Volume UIBlur { get; }
}
