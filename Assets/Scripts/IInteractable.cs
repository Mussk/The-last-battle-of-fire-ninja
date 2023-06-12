using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable 
{
    void Interact(Transform interactorTransform);
    string GetInteractText();
    Transform GetTransform();


}
