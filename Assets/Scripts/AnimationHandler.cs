using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    [SerializeField]
    protected Animator animator;

    [SerializeField]
    private Character character;

    [SerializeField]
    private GameEndController gameEndController;

    [SerializeField]
    private SFXSoundManager soundManager;

    [SerializeField]
    protected AudioSource deathSound;

    



    public void PlayDeathAnimation()
    {

        character.isMoving = false;
        animator.SetBool("IsDead", true);
        animator.Play("Death");

        soundManager.PlaySound(deathSound.name);

    }

    //this method is called by Death animation
    public void DeathAnimationEvent()
    {
        if (character is Enemy)
        {

            CoinsManager.Instance.CoinsAmountThisGame =
                CoinsManager.Instance.ChangeCoinsAmount(CoinsManager.Instance.CoinsAmountThisGame,
                character.gameObject.GetComponent<Enemy>().CoinsReward);



            SpawnManager.spawnedEnemies.Remove(character.gameObject);
            Destroy(character.gameObject);

        }
        else
        {
            
            gameEndController.InitializeGameEnd();

        }
    }

}
