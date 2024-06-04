using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 
 * Fireball which will fly and explode then collide with an enemy dealing  AOE damage
 * 
 * **/
public class Fireball : PlayerProjectile, IHasCooldown
{
    
    [SerializeField]
    private LayerMask destructable;

    

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


    }

    private void CheckAOEDamage() 
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f, destructable);

        foreach (Collider collider in colliders) 
        {

            if (collider.GetComponent<Enemy>()) 
            {

                collider.GetComponent<Enemy>().HealthSystem.ChangeHealth(-DamageAmount);

            }

        }
    }

    protected override void OnTriggerEnter(Collider other) 
    {

        base.OnTriggerEnter(other);


        CheckAOEDamage();

    }
}
