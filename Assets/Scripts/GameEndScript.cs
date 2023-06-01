using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndScript : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private GameObject gameOverBackgorund;

    [SerializeField]
    private UIBlur uIBlur;

    void Start()
    {
       
    }

    void Update()
    {
        if (gameOverBackgorund.gameObject.activeSelf)
        {

            uIBlur.Intensity += 0.7f * Time.deltaTime;
        
        }

        if (uIBlur.Intensity == 1)
        {

            Time.timeScale = 0;
        
        }
    }

    public void InitializeGameEnd()
    {
        gameOverBackgorund.gameObject.SetActive(true);
      
        gameOverText.gameObject.SetActive(true);

    }
}
