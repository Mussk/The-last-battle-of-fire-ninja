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

        playButton.onClick.AddListener(delegate { sceneManipulationButtons.LoadNewSceneOnClick(0); });
        shopButton.onClick.AddListener(delegate { sceneManipulationButtons.LoadNewSceneOnClick(1); });
        settingsButton.onClick.AddListener(delegate { OpenSettingsUIWindow(); });
        creditsButton.onClick.AddListener(delegate { OpenCreditsUIWindow(); });
        quitButton.onClick.AddListener(sceneManipulationButtons.QuitApplication);


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OpenSettingsUIWindow()
    {

        settingsUIWindow.gameObject.SetActive(true);

        Time.timeScale = 0;

        settingsUIWindow.UIBlur.enabled = true;

    }

    private void OpenCreditsUIWindow()
    {
        creditsUIWindow.gameObject.SetActive(true);

        Time.timeScale = 0;

        creditsUIWindow.UIBlur.enabled = true;

    }

}
