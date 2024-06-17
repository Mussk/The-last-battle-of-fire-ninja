using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSoundManager : MonoBehaviour
{

    public AudioSource[] characterSounds;

    [SerializeField]
    private Character character;

    private bool deathSoundIsPlayed;

    private void Awake()
    {
        deathSoundIsPlayed = false;
    }

    public void PlaySound(string soundName) 
    { 
    
        foreach (var sound in characterSounds) 
        {   
            
            if (sound.name.Equals(soundName)) 
            {
                
                if (character.HealthSystem.CurrentHealth > 0) 
                {

                    sound.Play();

                }

                if(character.HealthSystem.CurrentHealth == 0 && soundName.EndsWith("DeathSound") && !deathSoundIsPlayed)
                {
                   
                    sound.Play();
                    deathSoundIsPlayed = true;
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

                if (character.HealthSystem.CurrentHealth > 0)
                {

                    sound.PlayDelayed(delay);

                }

                if (character.HealthSystem.CurrentHealth == 0 && soundName.EndsWith("DeathSound") && !deathSoundIsPlayed)
                {
                    sound.PlayDelayed(delay);
                    deathSoundIsPlayed = true;
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
