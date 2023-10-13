using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
