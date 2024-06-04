using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProjectile : Projectile, IHasCooldown
{
   
    [Header("Settings")]
    [SerializeField]
    private int id;
    [SerializeField]
    private float cooldownDuration;

    public int Id => id;

    public float CooldownDuration => cooldownDuration;

  

    // Start is called before the first frame update
    protected virtual void Start()
    {
        actor = GameObject.FindGameObjectWithTag("Player");

    }

    

    // Update is called once per frame
    protected override void Update()
    {
       base.Update();
    }
    
    //Enemy collision
    protected override void OnTriggerEnter(Collider other)
    {   
        base.OnTriggerEnter(other);

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
