using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCloseButton : MonoBehaviour
{
    [SerializeField]
    private ShopController shopWindow;

    [SerializeField]
    private Button shopCloseButton;

    // Start is called before the first frame update
    void Start()
    {
        shopCloseButton.onClick.AddListener(ShopCloseButtonOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void ShopCloseButtonOnClick()
    {

        shopWindow.UIBlur.Intensity = 0;

        shopWindow.gameObject.SetActive(false);

    }
}
