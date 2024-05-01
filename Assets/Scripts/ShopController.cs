using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class ShopController : BaseController<SkinData>, IUIWindow, IDataPersistence<SkinData>
{

    [field: SerializeField]
    public GameObject UIWindowObject { get; set; }

    [field: SerializeField]
    public Volume UIBlur { get; set; }

    public int CoinsAmountOverall { get; set; }

    [SerializeField]
    public TextMeshProUGUI coinsText;

    [SerializeField]
    private List<ShopItemUIController> shopItems;

    public bool IsDefaultPrices { get; set; } = false;

    [SerializeField]
    private SoundPlayer soundPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (var item in shopItems)
        {
            if (IsDefaultPrices)
            {

                item.UpdatePrice(item.playerSkinScriptableObject.DefaultPrice);
                item.playerSkinScriptableObject.CurrentPrice = item.playerSkinScriptableObject.DefaultPrice;
            }
            else
            {

                item.UpdatePrice(item.playerSkinScriptableObject.CurrentPrice);

            }
        }
       
    }
    private void OnEnable()
    {
        CoinsAmountOverall = PlayerPrefs.GetInt("CoinsAmountOverall");

        coinsText.text = CoinsAmountOverall.ToString();

        CheckPrices();

        soundPlayer.PlaySound();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("CoinsAmountOverall", CoinsAmountOverall);

        Debug.Log(PlayerPrefs.GetInt("CoinsAmountOverall"));

        soundPlayer.PlaySound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks what player can buy in the shop
    public void CheckPrices()
    {
        foreach (ShopItemUIController shopItem in shopItems) 
        {

            Button button = shopItem.BuyItemButton;

            int.TryParse(button.GetComponentInChildren<TextMeshProUGUI>().text, out int price);
            Debug.Log(price);
            if (CoinsAmountOverall < price)
            {
                button.interactable = false;
            }
        
        }

    }

    public override void LoadData(SkinData data)
    {   

        var serializedSkins = data.OwnedSkinsData;
        if(serializedSkins.Count > 0) { 
            
            foreach (var shopItem in shopItems) 
            {
                var skinItemInShop = shopItem.playerSkinScriptableObject;

                if (serializedSkins.Contains(skinItemInShop.Material.name))
                {
                    foreach (var serializedSkin in serializedSkins)
                    {
                        if (serializedSkin.Equals(skinItemInShop.Material.name))
                        {
                            skinItemInShop.MarkAsBought();
                        }
                
                    }

                }

            }
        }
    }
    public override void SaveData(ref SkinData dataToSave)
    {

        foreach(var skinItemInShop in shopItems) 
        {   
            var skinItemShopProperties = skinItemInShop.playerSkinScriptableObject;

            if(skinItemShopProperties.CurrentPrice == 0)
            {
                dataToSave.OwnedSkinsData.Add(skinItemShopProperties.Material.name);
            }
        
        }
    }

    public override void InitDefaultData()
    {
        IsDefaultPrices = true;
    }

   
}
