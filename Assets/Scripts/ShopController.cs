using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Krivodeling.UI.Effects;

public class ShopController : MonoBehaviour, IUIWindow
{

    [field: SerializeField]
    public GameObject UIWindowObject { get; set; }

    [field: SerializeField]
    public UIBlur UIBlur { get; set; }

    public int CoinsAmountOverall { get; set; }

    [SerializeField]
    public TextMeshProUGUI coinsText;

    [SerializeField]
    private List<ShopItemUIController> shopItems;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (var item in shopItems)
        {
            item.InitializePrice();
        }
    }

    private void OnEnable()
    {
        CoinsAmountOverall = PlayerPrefs.GetInt("CoinsAmountOverall");

        coinsText.text = CoinsAmountOverall.ToString();

        CheckPrices();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("CoinsAmountOverall", CoinsAmountOverall);

        Debug.Log(PlayerPrefs.GetInt("CoinsAmountOverall"));
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
}
