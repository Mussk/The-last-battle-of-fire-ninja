using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private List<Button> buyButtons;

    // Start is called before the first frame update
    void Start()
    {
        CheckPrices();
    }

    private void OnEnable()
    {
        CheckPrices();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks what player can buy in the shop
    public void CheckPrices()
    {
        foreach (var button in buyButtons) 
        {
            int.TryParse(button.GetComponentInChildren<TextMeshProUGUI>().text, out int price);
            Debug.Log(button.GetComponentInChildren<TextMeshProUGUI>().text);
            Debug.Log(price);
            if (playerController.CoinsCount < price)
            {
                button.interactable = false;
            }
        
        }

    }
}
