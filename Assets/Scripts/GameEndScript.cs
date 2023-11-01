using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour, IUIWindow
{

    [SerializeField]
    private GameObject _gameEndUIObject;

    [SerializeField]
    private Volume _uIBlur;

    public GameObject UIWindowObject => _gameEndUIObject;

    public Volume UIBlur => _uIBlur;

    [SerializeField]
    private Button newGameButton;

    [SerializeField]
    private Button mainMenuButton;

    private SceneManipulationButtons sceneManipulationButtons;

    [SerializeField]
    private SoundPlayer sceneManipulationButtonsSound, gameEndMusic;

    [SerializeField]
    private GameObject backgroundSoundLayer;

    void Start()
    {
        _gameEndUIObject.SetActive(false);

        sceneManipulationButtons = new SceneManipulationButtons(sceneManipulationButtonsSound);

        newGameButton.onClick.AddListener(sceneManipulationButtons.ReloadCurrenSceneOnClick);

        mainMenuButton.onClick.AddListener(delegate { sceneManipulationButtons.LoadNewSceneOnClick(2); });
    }

    public void InitializeGameEnd()
    {
        

        _gameEndUIObject.SetActive(true);
        _uIBlur.enabled = true;
        gameEndMusic.PlaySound();    
        StopBackgroundLayerSounds();

        CoinsManager.Instance.CoinsAmountOverall = 
            CoinsManager.Instance.ChangeCoinsAmount(CoinsManager.Instance.CoinsAmountOverall,
            CoinsManager.Instance.CoinsAmountThisGame);

    }

    private void StopBackgroundLayerSounds()
    {

        backgroundSoundLayer.GetComponents<AudioSource>().ToList().ForEach(audioSource => audioSource.Pause());

    }

}
