using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour, IUIWindow
{

    public static bool IsPaused;

    [SerializeField]
    private GameObject _pauseMenuUIObject;

    [SerializeField]
    private UIBlur _uIBlur;

    public GameObject UIWindowObject => _pauseMenuUIObject;
  
    public UIBlur UIBlur => _uIBlur;

    private SceneManipulationButtons sceneManipulationButtons;

    [SerializeField]
    private SoundPlayer soundPlayer;

    [Header("Buttons")]
    [SerializeField]
    private Button mainMenuButton;
    [SerializeField]
    private Button resumeButton;


    
    void Awake()
    {
        _pauseMenuUIObject.SetActive(true);
        _uIBlur.Intensity = 0;
        _pauseMenuUIObject.SetActive(false);
        
        IsPaused = false;
        Time.timeScale = 1;
        
        sceneManipulationButtons = new SceneManipulationButtons(soundPlayer);

        resumeButton.onClick.AddListener(UnpauseGameOnClick);
        mainMenuButton.onClick.AddListener(delegate { sceneManipulationButtons.LoadNewSceneOnClick(2); });
        

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (!IsPaused)
            {
                Time.timeScale = 0;

                IsPaused = true;
                _pauseMenuUIObject.SetActive(true);
                soundPlayer.PlaySound();
                _uIBlur.Intensity = 1;
                
            } 
            else
            {
                IsPaused = false;
                soundPlayer.PlaySound();
                _pauseMenuUIObject.SetActive(false);

                _uIBlur.Intensity = 0;

                Time.timeScale = 1;

            }

        }
    }


    private void UnpauseGameOnClick()
    {

        IsPaused = false;
        soundPlayer.PlaySound();
        _pauseMenuUIObject.SetActive(false);
        
        _uIBlur.Intensity = 0;

        Time.timeScale = 1;

    }
}
