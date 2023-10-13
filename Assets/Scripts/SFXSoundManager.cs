using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSoundManager : MonoBehaviour
{

    public AudioSource[] characterSounds;

    [SerializeField]
    private Character character;

    public void PlaySound(string soundName) 
    { 
    
        foreach (var sound in characterSounds) 
        {   
            
            if (sound.name.Equals(soundName)) 
            {
                
                if (character.HealthSystem.currentHealth > 0) 
                {

                    sound.Play();

                }

                if(character.HealthSystem.currentHealth == 0 && soundName.EndsWith("DeathSound"))
                {
                    Debug.Log("PlayDeathSound: " + character.name);
                    sound.Play();
                }
 
            }
        
        }
    
    }

    public void PlaySound(string soundName, float delay)
    {

        foreach (var sound in characterSounds)
        {

            if (sound.name.Equals(soundName))
            {

                if (character.HealthSystem.currentHealth > 0)
                {

                    sound.PlayDelayed(delay);

                }

                if (character.HealthSystem.currentHealth == 0 && soundName.EndsWith("DeathSound"))
                {
                    sound.PlayDelayed(delay);
                }

            }

        }

    }

    public void StopSound(string soundName) 
    {

        foreach (var sound in characterSounds)
        {

            if (sound.name.Equals(soundName))
            {

                sound.Stop();

            }

        }


    }
}
