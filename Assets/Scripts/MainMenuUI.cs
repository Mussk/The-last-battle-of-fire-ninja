using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button shopButton;

    [SerializeField]
    private Button settingsButton;

    [SerializeField]
    private Button creditsButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private SoundPlayer soundPlayer;

    [SerializeField]
    private SettingsController settingsUIWindow;

    [SerializeField]
    private CreditsController creditsUIWindow;

    private SceneManipulationButtons sceneManipulationButtons;

    // Start is called before the first frame update
    void Start()
    {
        sceneManipulationButtons = new SceneManipulationButtons(soundPlayer);

        playButton.onClick.AddListener(delegate { sceneManipulationButtons.LoadNewSceneOnClick(1); });
        shopButton.onClick.AddListener(delegate { sceneManipulationButtons.LoadNewSceneOnClick(2); });
        settingsButton.onClick.AddListener(delegate { ShowUIWindow(settingsUIWindow); });
        creditsButton.onClick.AddListener(delegate { ShowUIWindow(creditsUIWindow); });
        quitButton.onClick.AddListener(sceneManipulationButtons.QuitApplication);


    }

    

    private void ShowUIWindow(IUIWindow windowToShow)
    {
        windowToShow.UIWindowObject.SetActive(true);

        Time.timeScale = 0;

        windowToShow.UIBlur.enabled = true;
    }

}
