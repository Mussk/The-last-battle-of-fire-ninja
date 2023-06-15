using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopItemUIController : MonoBehaviour
{
    [SerializeField]
    private Button buyItemButton;

    [SerializeField]
    private PlayerSkinScriptableObject playerSkinScriptableObject;

    [SerializeField]
    private List<GameObject> playerModelPartsToColor;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private ShopController shopController;

    // Start is called before the first frame update
    void Awake()
    {
        buyItemButton.onClick.AddListener(BuyItemButtonOnClick);
        buyItemButton.GetComponentInChildren<TextMeshProUGUI>().text = 
            playerSkinScriptableObject.Price.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void BuyItemButtonOnClick() 
    {   
        if (playerController.CoinsCount >= playerSkinScriptableObject.Price)
        {

            playerController.CoinsCount -= playerSkinScriptableObject.Price;

            foreach (var modelPart in playerModelPartsToColor)
                modelPart.GetComponent<Renderer>().material
                    = playerSkinScriptableObject.Material;

            Debug.Log(playerController.CoinsCount);

            shopController.CheckPrices();
        }
       

    }
}
