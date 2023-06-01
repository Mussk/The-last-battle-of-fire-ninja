using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        
        _damageAmount = 20;

        _currentHealth = 150;

        _currentMaxHealth = 150; 

        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }



    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if(other.CompareTag("Player"))
        {

            animator.SetBool("IsAttacking", true);
            isMoving = false;

        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.CompareTag("Player")) 
        { 
            animator.SetBool("IsAttacking", false);
            isMoving = true;

        }
    }
   
    
        
    
   
}
