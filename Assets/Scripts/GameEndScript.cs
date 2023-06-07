using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour, IUIWindow
{

    [SerializeField]
    private GameObject _gameEndUIObject;

    [SerializeField]
    private UIBlur _uIBlur;

    public GameObject UIWindowObject => _gameEndUIObject;

    public UIBlur UIBlur => _uIBlur;

    [SerializeField]
    private Button newGameButton;

    void Start()
    {
        _gameEndUIObject.SetActive(false);

        newGameButton.onClick.AddListener(ReloadSceneOnClick);
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


    private void LoadNewSceneOnClick(int sceneBuildIndex)
    {

        SceneManager.LoadScene(sceneBuildIndex);

    }

    private void ReloadSceneOnClick()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
