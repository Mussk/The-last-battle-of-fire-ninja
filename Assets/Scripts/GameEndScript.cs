using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndScript : MonoBehaviour
{

    [SerializeField]
    private GameObject gameOverBackgorund;

    [SerializeField]
    private GameObject GameEndUIObject;

    [SerializeField]
    private UIBlur uIBlur;

    void Start()
    {
        GameEndUIObject.SetActive(false);
    }

    void Update()
    {
        if (gameOverBackgorund.gameObject.activeInHierarchy)
        {

            uIBlur.Intensity += 0.7f * Time.deltaTime;
        
        }

    }

    public void InitializeGameEnd()
    {

        GameEndUIObject.SetActive(true);
    }
}
