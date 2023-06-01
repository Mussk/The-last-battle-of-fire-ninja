using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAnimationHandler : AnimationHandler
{

    [SerializeField]
    private PlayerController playerController;

    private Vector3 playerInput;

    
    //private Animator animator;


    private AnimatorControllerParameter[] animationParameters;

    // Start is called before the first frame update
    void Start()
    {
        animationParameters = animator.parameters;
    }

    // Update is called once per frame
    void Update()
    {
        
        HandleMovementAniamtions();
    }

    private void HandleMovementAniamtions()
    {
        playerInput = playerController.PlayerInput.ToIso();


        float velocityX = Vector3.Dot(playerInput.normalized, transform.right);
        float velocityZ = Vector3.Dot(playerInput.normalized, transform.forward);


        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime); 

    }

    public void PlayDaggerThrowAnimation() 
    {

        animator.SetBool("IsThrowingDagger", true);

        animator.Play("PunchRight",1);

        animator.SetBool("IsThrowingDagger", false);
        
    }

    public void PlayFireballAnimation()
    {

        animator.SetBool("IsCastingFireball", true);

        animator.Play("SpellCast", 1);

        animator.SetBool("IsCastingFireball", false);

    }


    public void PlaySiphonCastAnimation() 
    {

        animator.SetBool("IsCastingSiphon", true);

        animator.Play("Siphon",1);

    }

    public void StopSiphonAnimation() 
    {

        animator.SetBool("IsCastingSiphon", false);

        
    
    }

    public void PlayFirestormAnimation()
    {

        animator.SetBool("IsCastingFirestorm", true);

        animator.Play("FirestormCast",1);

        animator.SetBool("IsCastingFirestorm", false);

    }

}
