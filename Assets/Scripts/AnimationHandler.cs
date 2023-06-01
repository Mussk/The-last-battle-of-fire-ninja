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


    }

    //this method is called by Death animation
    public void DeathAnimationEvent()
    {
        if (character is Enemy) 
        {
            character.gameObject.SetActive(false);
        }
        else
        {

            gameEnd.InitializeGameEnd();

        }
    }
}
