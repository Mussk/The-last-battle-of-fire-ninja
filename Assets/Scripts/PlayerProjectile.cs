using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProjectile : Projectile, IHasCooldown
{
   
    [Header("Settings")]
    [SerializeField]
    private int id = 1;
    [SerializeField]
    private float cooldownDuration = 2.0f;
   
    public int Id => id;

    public float CooldownDuration => cooldownDuration;
  

    // Start is called before the first frame update
    protected virtual void Start()
    {
        actor = GameObject.Find("Player");

        _damageAmount = 50;
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
