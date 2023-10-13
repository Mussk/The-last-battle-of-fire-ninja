using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnUIButtonHover : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private SoundPlayer soundPlayer;

    public void OnPointerEnter(PointerEventData eventData)
    {
        soundPlayer.PlaySound();
    }

   
}
