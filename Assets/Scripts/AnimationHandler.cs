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
    private GameEndScript gameEnd;

    public void PlayDeathAnimation()
    {

        character.isMoving = false;
        animator.SetBool("IsDead", true);
        animator.Play("Death");

        PlayDeathSound();

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
            character.SFXManager.PlaySound("PlayerDeathSound");
            gameEnd.InitializeGameEnd();

        }
    }

    private void PlayDeathSound() 
    {
        if (character is EnemyMelee)
        {

            character.SFXManager.PlaySound("MeleeEnemyDeathSound");

        }
        if (character is EnemyDagger)
        {

            character.SFXManager.PlaySound("BowEnemyDeathSound");

        }
    }
}
