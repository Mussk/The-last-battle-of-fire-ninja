using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class NPCInteractable : MonoBehaviour, IInteractable
{

    [SerializeField]
    private string interactText;

    
    public ShopController ShopUI;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Transform interactorTransform)
    {
        if (!ShopUI.UIWindowObject.activeSelf) 
        { 
            ShopUI.UIWindowObject.SetActive(true);

            ShopUI.UIBlur.enabled = true;
        }
        else
        {
            Debug.Log("Window is already shown");
        }    
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

}
