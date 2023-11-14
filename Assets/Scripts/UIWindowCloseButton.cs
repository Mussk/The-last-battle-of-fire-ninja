using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWindowCloseButton : MonoBehaviour
{
    [SerializeField]
    private GameObject uiWindowComponent;

    private IUIWindow uiWindow;

    [SerializeField]
    private Button closeButton;

    //maybe change IUIWindow interface to abstract class?
    protected void OnValidate()
    {
        if (!(uiWindowComponent.GetComponent<IUIWindow>() is IUIWindow))
            uiWindowComponent = null;
    }
    protected void Awake()
    {
        if (uiWindowComponent != null)
            uiWindow = uiWindowComponent.GetComponent<IUIWindow>() as IUIWindow;
    }

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(UIWindowCloseButtonOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void UIWindowCloseButtonOnClick()
    {

        uiWindow.UIBlur.enabled = false;

        uiWindow.UIWindowObject.SetActive(false);

    }
}
