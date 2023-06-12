using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManipulationButtons
{
    public void LoadNewSceneOnClick(int sceneBuildIndex)
    {

        SceneManager.LoadScene(sceneBuildIndex);

    }

    public void ReloadCurrenSceneOnClick()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitApplication()
    {

        Application.Quit();

    }

}
