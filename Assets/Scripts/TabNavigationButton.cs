using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabNavigationButton : MonoBehaviour
{
    [Header("Insert in order as in game")]
    [field: SerializeReference]
    private List<GameObject> Tabs;


    [SerializeField]
    private bool isForward;


    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<Button>().onClick.AddListener(delegate { ChangeTab(isForward); });

    }

    private void ChangeTab(bool isForward)
    {

        foreach (GameObject tab in Tabs) 
        {

            if (tab.activeSelf)
            {

                if (isForward && Tabs.IndexOf(tab) < Tabs.Count-1)
                {
                    tab.SetActive(false);
                    Tabs[Tabs.IndexOf(tab) + 1].SetActive(true);
                    
                    

                }
                else if(!isForward && Tabs.IndexOf(tab) > 0)
                {
                    tab.SetActive(false);
                    Tabs[Tabs.IndexOf(tab) - 1].SetActive(true);
                    

                }

                break;
            } 

        }

    }

}
