using UnityEngine;
using UnityEngine.Rendering;

public class CreditsController : MonoBehaviour, IUIWindow
{
    [field: SerializeField]
    public GameObject UIWindowObject { get; set; }

    [field: SerializeField]
    public Volume UIBlur { get; set; }

    
}
