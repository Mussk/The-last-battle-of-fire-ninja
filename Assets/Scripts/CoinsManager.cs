using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{

    private static CoinsManager _instance;

    public static CoinsManager Instance 
    {
        get
        {

            if (_instance is null) 
            {
            
                Debug.LogError("CoinsManager is null!");
            
            }
            return _instance;

        }
    }
    public int coinsAmountDebug = 3000;
    [SerializeField]
    public int CoinsAmountOverall { get => PlayerPrefs.GetInt("CoinsAmountOverall");
        set => PlayerPrefs.SetInt("CoinsAmountOverall", value); }


    private int _coinsAmountThisGame;
    public int CoinsAmountThisGame { get => _coinsAmountThisGame;
        set => _coinsAmountThisGame = value; }

    [field: SerializeField]
    private TextMeshProUGUI CoinsText { get; set; }

    [field: SerializeField]
    public int CoinsRemovedOnDamageTaken { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {

        _instance = this;

        CoinsAmountThisGame = 0;

        CheckCoinsPersistency();

        Debug.Log(CoinsAmountOverall);

    }

    private void UpdateCoinsText(int valueToUpdate)
    {

        CoinsText.text = valueToUpdate.ToString();

    }

    public int ChangeCoinsAmount(int valueToChange, int changeAmount)
    {

        int result = Mathf.Max(valueToChange + changeAmount,0);
        
        UpdateCoinsText(result);

        return result;
    }

    private void CheckCoinsPersistency()
    {
        if (!PlayerPrefs.HasKey("CoinsAmountOverall"))
        {
            PlayerPrefs.SetInt("CoinsAmountOverall", 0);
        }
    }

}
