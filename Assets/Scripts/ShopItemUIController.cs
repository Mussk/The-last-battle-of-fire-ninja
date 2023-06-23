using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopItemUIController : MonoBehaviour
{
    [field: SerializeField]
    public Button BuyItemButton { get; private set; }

    [SerializeField]
    private PlayerSkinScriptableObject playerSkinScriptableObject;

    [SerializeField]
    private List<GameObject> playerModelPartsToColor;

    [SerializeField]
    private ShopController shopController;

    // Start is called before the first frame update
    void Awake()
    {
       
        BuyItemButton.onClick.AddListener(BuyItemButtonOnClick);

    }

 
    private void BuyItemButtonOnClick() 
    {   
        if (shopController.CoinsAmountOverall >= playerSkinScriptableObject.Price)
        {

            shopController.CoinsAmountOverall -= playerSkinScriptableObject.Price;

            shopController.coinsText.text = shopController.CoinsAmountOverall.ToString();

            foreach (var modelPart in playerModelPartsToColor)
                modelPart.GetComponent<Renderer>().material
                    = playerSkinScriptableObject.Material;

            shopController.CheckPrices();
        }
       

    }


   public void InitializePrice()
   {
        BuyItemButton.GetComponentInChildren<TextMeshProUGUI>().text =
           playerSkinScriptableObject.Price.ToString();
   }


}
