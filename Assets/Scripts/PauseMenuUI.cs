using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour, IUIWindow
{

    public static bool IsPaused;

    [SerializeField]
    private GameObject _pauseMenuUIObject;

    [SerializeField]
    private Volume _uIBlur;

    public GameObject UIWindowObject => _pauseMenuUIObject;
  
    public Volume UIBlur => _uIBlur;

    private SceneManipulationButtons sceneManipulationButtons;

    [SerializeField]
    private GameObject SettingsUI;

    [SerializeField]
    private SoundPlayer soundPlayer;

    [Header("Buttons")]
    [SerializeField]
    private Button mainMenuButton;
    [SerializeField]
    private Button resumeButton;
    [SerializeField]
    private Button settingsButton;


    
    void Awake()
    {
        _pauseMenuUIObject.SetActive(true);
       
        _pauseMenuUIObject.SetActive(false);
        
        IsPaused = false;
        Time.timeScale = 1;
        
        sceneManipulationButtons = new SceneManipulationButtons(soundPlayer);

        resumeButton.onClick.AddListener(UnpauseGameOnClick);
        mainMenuButton.onClick.AddListener(delegate { sceneManipulationButtons.LoadNewSceneOnClick(0); });
        settingsButton.onClick.AddListener(delegate { ShowSettingsWindow(); });
        

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            if (!IsPaused)
            {
                Time.timeScale = 0;

                IsPaused = true;
                _pauseMenuUIObject.SetActive(true);
                soundPlayer.PlaySound();
                _uIBlur.enabled = true;
                
            } 
            else
            {
                IsPaused = false;
                soundPlayer.PlaySound();
                _pauseMenuUIObject.SetActive(false);

                _uIBlur.enabled = false;

                Time.timeScale = 1;

            }

        }
    }


    private void UnpauseGameOnClick()
    {

        IsPaused = false;
        soundPlayer.PlaySound();
        _pauseMenuUIObject.SetActive(false);

        _uIBlur.enabled = false;    

        Time.timeScale = 1;

    }

    private void ShowSettingsWindow() 
    {
        if (!SettingsUI.activeSelf) 
        { 
            SettingsUI.SetActive(true);
            
        }


    }
}