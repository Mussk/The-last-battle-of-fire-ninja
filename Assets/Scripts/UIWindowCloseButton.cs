using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIWindowCloseButton : MonoBehaviour
{
    [SerializeField]
    private GameObject uiWindowComponent;

    private IUIWindow uiWindow;

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
        gameObject.GetComponent<Button>().onClick.AddListener(UIWindowCloseButtonOnClick);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void UIWindowCloseButtonOnClick()
    {   

        if(SceneManager.GetActiveScene().buildIndex == 0) 
        {

            Time.timeScale = 1;

        }

        if (Time.timeScale == 1) 
        {   

            uiWindow.UIBlur.enabled = false;

        }
        uiWindow.UIWindowObject.SetActive(false);

    }
}
