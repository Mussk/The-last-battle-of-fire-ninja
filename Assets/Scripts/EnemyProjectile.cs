using UnityEngine;

public class EnemyProjectile : Projectile
{

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    protected override void Update()
    { 
          
        transform.Translate(speed * Time.deltaTime * direction, Space.World);
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
