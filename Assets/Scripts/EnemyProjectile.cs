using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{

    // Start is called before the first frame update
    void Start()
    {
        _damageAmount = 5;
    }

    // Update is called once per frame
    protected override void Update()
    { 
          
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }

    //Enemy collision
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
