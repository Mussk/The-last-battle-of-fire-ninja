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


    [Header("Buttons")]
    [SerializeField]
    private Button mainMenuButton;
    [SerializeField]
    private Button resumeButton;


    // Start is called before the first frame update
    void Start()
    {
        _pauseMenuUIObject.SetActive(true);
        _pauseMenuUIObject.SetActive(false);
        IsPaused = false;

        resumeButton.onClick.AddListener(UnpauseGameOnClick);

        
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

                _uIBlur.Intensity = 1;
                
            } 
            else
            {
                IsPaused = false;

                _pauseMenuUIObject.SetActive(false);

                _uIBlur.Intensity = 0;

                Time.timeScale = 1;

            }

        }
    }


    private void UnpauseGameOnClick()
    {

        IsPaused = false;

        _pauseMenuUIObject.SetActive(false);

        _uIBlur.Intensity = 0;

        Time.timeScale = 1;

    }
}
