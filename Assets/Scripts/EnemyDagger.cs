using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDagger : Enemy, IShootable
{
    public GameObject projectileEnemyDagger;

    private EnemyProjectile enemyProjectile;

    [SerializeField]
    private Transform projectilesSpawner;



    protected override void Start()
    {
        
        _damageAmount = 10;

        _currentHealth = 100;

        _currentMaxHealth = 100;

        enemyProjectile = projectileEnemyDagger.GetComponent<EnemyProjectile>();

        enemyProjectile.actor = this.gameObject;

        InvokeRepeating("PlayShootAnimation", 0.5f, 3.0f);

        base.Start();

    }

   

    // Update is called once per frame
    protected override void Update()
    {   

        base.Update();
        
    }

    public void Shoot()
    {

        enemyProjectile.direction = transform.forward;

        Instantiate(projectileEnemyDagger, projectilesSpawner.position, transform.rotation);

        SFXManager.PlaySound("BowEnemyArrowShotSound");

    }

    //this method is invoked by animation BowShot
    public void BowShootAnimationHandler() 
    {

        Shoot();

    }

    //this method is invoked by animation BowShot
    public void EndOfBowShootAnimationEvent() 
    {

        animator.SetBool("IsShootingBow", false);

    }

    private void PlayShootAnimation() 
    {
        if (animator.GetBool("IsDead") == false) 
        { 

            animator.SetBool("IsShootingBow", true);
            animator.Play("BowShot");
            SFXManager.PlaySound("BowEnemyVoiceAttackSound", Random.Range(0.1f, 0.3f));
            SFXManager.PlaySound("BowEnemyStringPullSound");
            
        }

    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

   
}
