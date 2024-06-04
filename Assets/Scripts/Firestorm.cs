using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firestorm : MonoBehaviour, IHasCooldown, IDealDamage
{
    [Header("Firestorm sizes")]
    [SerializeField]
    private float initialSizeX;
    [SerializeField]
    private float initialSizeZ;
    [SerializeField]
    private float maxSizeX;
    [SerializeField]
    private float maxSizeZ;


    private Vector3 initialSize;
    private Vector3 maxSize;

    private float startTime;

    private float journeyLength;

    [Header("Settings")]
    [SerializeField]
    private int id = 4;
    [SerializeField]
    private float cooldownDuration = 2.0f;
    [SerializeField]
    private float speed;


    public int Id => id;

    public float CooldownDuration => cooldownDuration;

    [SerializeField]
    private int _damageAmount;
    public int DamageAmount => _damageAmount;


    // Start is called before the first frame update
    void Start()
    {
        initialSize = new Vector3(initialSizeX, transform.localScale.y, initialSizeZ);
        maxSize = new Vector3(maxSizeX, transform.localScale.y, maxSizeZ);

        startTime = Time.time;

        journeyLength = Vector3.Distance(initialSize, maxSize);

        
    }

    // Update is called once per frame
    void Update()
    {
            
        float distCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = distCovered / journeyLength;

        transform.localScale = Vector3.Lerp(initialSize, maxSize, fractionOfJourney);


        if (transform.localScale.x == maxSizeX && transform.localScale.z == maxSizeZ)
        {
                    
            Destroy(gameObject);

        }
      
    }

}
    