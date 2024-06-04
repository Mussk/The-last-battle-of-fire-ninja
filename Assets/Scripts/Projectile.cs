using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour, IDealDamage
{
    public float speed = 10;

    public GameObject actor;
    public Vector3 direction;
    protected bool isShooted = false;

    [SerializeField]
    protected int _damageAmount;

    public int DamageAmount => _damageAmount;


    // Update is called once per frame
    protected virtual void Update()
    {
        if (!isShooted) {
            
            direction = actor.transform.forward;          
            isShooted = true;
            
        }

        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //Wall collisions
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {

            Destroy(gameObject);

        }
    }
}
