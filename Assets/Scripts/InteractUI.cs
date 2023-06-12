using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractUI : WorldSpaceUI
{

    [SerializeField]
    private PlayerInteract playerInteract;

    [SerializeField]
    private TextMeshProUGUI interactText;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }

    private void Update()
    {

       if(playerInteract.GetInteractableObject() != null)
       {
            Show(playerInteract.GetInteractableObject());
       }
       else
       {
            Hide();
       }
    }

    private void Show(IInteractable interactable)
    {
        uiObject.SetActive(true);
        interactText.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        uiObject.SetActive(false);
    }
}
