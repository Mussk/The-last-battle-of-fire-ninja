using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndScript : MonoBehaviour, IUIWindow
{

    [SerializeField]
    private GameObject _gameEndUIObject;

    [SerializeField]
    private UIBlur _uIBlur;

    public GameObject UIWindowObject => _gameEndUIObject;

    public UIBlur UIBlur => _uIBlur;

    void Start()
    {
        _gameEndUIObject.SetActive(false);
    }

    void Update()
    {
        if (_gameEndUIObject.activeInHierarchy)
        {

            _uIBlur.Intensity += 0.7f * Time.deltaTime;
        
        }

    }

    public void InitializeGameEnd()
    {

        _gameEndUIObject.SetActive(true);
    }
}
