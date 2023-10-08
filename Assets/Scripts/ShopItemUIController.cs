using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopItemUIController : MonoBehaviour
{
    [field: SerializeField]
    public Button BuyItemButton { get; private set; }

    [field: SerializeField]
    public PlayerSkinScriptableObject playerSkinScriptableObject { get; private set; }

    [SerializeField]
    private ShopController shopController;

    [SerializeField]
    private PlayerSkinHandler playerSkinHandler;

    // Start is called before the first frame update
    void Awake()
    {
       
        BuyItemButton.onClick.AddListener(BuyItemButtonOnClick);
        
    }

 
    private void BuyItemButtonOnClick() 
    {   
        if (shopController.CoinsAmountOverall >= playerSkinScriptableObject.CurrentPrice)
        {

            shopController.CoinsAmountOverall -= playerSkinScriptableObject.CurrentPrice;

            playerSkinScriptableObject.MarkAsBought();

            UpdatePrice(playerSkinScriptableObject.CurrentPrice);

            shopController.coinsText.text = shopController.CoinsAmountOverall.ToString();

            playerSkinHandler.SetCurrentSkin(playerSkinScriptableObject);

            playerSkinHandler.ApplySkin();

            shopController.CheckPrices();
        }
       

    }


    public void UpdatePrice(int price)
    {
        BuyItemButton.GetComponentInChildren<TextMeshProUGUI>().text =
       price.ToString();

    }


}
