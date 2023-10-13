using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManipulationButtons
{   

    private SoundPlayer soundPlayer;

    public SceneManipulationButtons(SoundPlayer soundPlayer) 
    {

        this.soundPlayer = soundPlayer;
    
    }

    public void LoadNewSceneOnClick(int sceneBuildIndex)
    {
        soundPlayer.PlaySound();
        SceneManager.LoadScene(sceneBuildIndex);

    }

    public void ReloadCurrenSceneOnClick()
    {
        soundPlayer.PlaySound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitApplication()
    {
        soundPlayer.PlaySound();
        Application.Quit();

    }

    public void PlaySoundOnHover()
    {
        soundPlayer.PlaySound();
    }

}
