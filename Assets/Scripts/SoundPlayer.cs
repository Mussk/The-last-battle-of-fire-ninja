using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [field: SerializeField]
    public AudioSource AudioSource { get; private set; }

    public void PlaySound() 
    {

        AudioSource.Play();
    
    }

    
}
