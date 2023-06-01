using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonListeners : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField]
    private Button mainMenuButton;
    [SerializeField]
    private Button newGameButton;


    // Start is called before the first frame update
    void Start()
    {
        
        newGameButton.onClick.AddListener(delegate { LoadNewSceneOnClick(0); });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void ReloadSceneOnClick()
    {
     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    

    
    private void LoadNewSceneOnClick(int sceneBuildIndex)
    {

        SceneManager.LoadScene(sceneBuildIndex);
    
    }
}
