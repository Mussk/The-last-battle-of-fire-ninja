using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Describes abstract enemy behaviour.
 * 
 * **/

public abstract class Enemy : Character, IHasHealth, IDealDamage
{
    protected GameObject player;
    public float moveSpeed = 1;
    public float rotationSpeed = 150;

    [SerializeField]
    private Healthbar _healthbar;

    [SerializeField]
    protected int _damageAmount;
    public int DamageAmount => _damageAmount;

    [SerializeField]
    protected Animator animator;

    protected Vector3 cachedPos;

    [SerializeField]
    private AnimationHandler animationHandler;

    [field: SerializeField]
    public int CoinsReward { get; private set; }

    [SerializeField]
    private AudioSource gotHitSound;

    [SerializeField]
    protected AudioSource attackSound;

    [SerializeField]
    protected AudioSource voiceAttackSound;

    // Start is called before the first frame update
    protected virtual void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        InitializeHealthSystem(_currentHealth, _currentMaxHealth);

        cachedPos = transform.position;
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        MoveTowardsPlayer();
    }

    //move towards player
    private void MoveTowardsPlayer()
    {
        if (isMoving && Vector3.Distance(player.transform.position, transform.position) > 1)
        {

            transform.LookAt(player.transform.position);

            transform.position += moveSpeed * Time.deltaTime * transform.forward;

            HandleEnemyAnimations(cachedPos, transform.position);

            cachedPos = transform.position;
        }
    }

    protected void InitializeHealthSystem(int currentHealth, int currentMaxHealth)
    {
        _currentHealth = currentHealth;
        _currentMaxHealth = currentMaxHealth;

        healthSystem = new HealthSystem(_currentHealth, _currentMaxHealth, animationHandler, _healthbar);


    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (this.isMoving)
        {

            GameObject otherGameObject = other.gameObject;

            if (otherGameObject.CompareTag("Projectile") ||
                otherGameObject.CompareTag("Siphon") ||
                otherGameObject.CompareTag("Firestorm"))
            {
                PlayRecieveDamageAnimation();

                SFXManager.PlaySound(gotHitSound.name);
            }


            if (other.gameObject.CompareTag("Projectile"))
            {

                healthSystem.ChangeHealth(-other.gameObject.GetComponent<Projectile>().DamageAmount);


            }



            if (other.gameObject.CompareTag("Firestorm"))
            {

                healthSystem.ChangeHealth(-other.gameObject.GetComponent<Firestorm>().DamageAmount);

            }

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Siphon"))
        {

            StartRecieveDoTDamage(other.gameObject.GetComponent<FireSiphon>().DamageAmount);
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {

    }


    public void StartRecieveDoTDamage(int damageAmount)
    {

        healthSystem.ChangeHealthOvertime(-damageAmount);

    }

    protected void HandleEnemyAnimations(Vector3 prevPos, Vector3 currentPos)
    {
        if (prevPos != currentPos)
        {

            animator.SetBool("IsMovingForward", true);
            animator.SetBool("IsIdle", false);

        }
        else
        {

            animator.SetBool("IsMovingForward", false);
            animator.SetBool("IsIdle", true);

        }


    }

    //this method is called by GetHit animation
    public void RecieveDamageAnimationEvent()
    {
        if (!animator.GetBool("IsDead"))
        {
            isMoving = true;


        }
    }


    private void PlayRecieveDamageAnimation()
    {
        isMoving = false;
        animator.SetBool("IsGettingHit", true);
        animator.Play("GetHit");
        animator.SetBool("IsGettingHit", false);

    }

}
