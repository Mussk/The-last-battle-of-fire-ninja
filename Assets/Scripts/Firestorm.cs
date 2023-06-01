using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firestorm : MonoBehaviour, IHasCooldown, IDealDamage
{
    private const float initialSizeX = 0;
    private const float initialSizeZ = 0;

    private const float maxSizeX = 15;
    private const float maxSizeZ = 15;

    private Vector3 initialSize;
    private Vector3 maxSize;

    [SerializeField]
    private float speed;

    private float startTime;

    private float journeyLength;

    [Header("Settings")]
    [SerializeField]
    private int id = 4;
    [SerializeField]
    private float cooldownDuration = 2.0f;


    public int Id => id;

    public float CooldownDuration => cooldownDuration;

    private int _damageAmount;
    public int DamageAmount => _damageAmount;


    // Start is called before the first frame update
    void Start()
    {
        initialSize = new Vector3(initialSizeX, transform.localScale.y, initialSizeZ);
        maxSize = new Vector3(maxSizeX, transform.localScale.y, maxSizeZ);

        startTime = Time.time;

        journeyLength = Vector3.Distance(initialSize, maxSize);

        _damageAmount = 150;

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
    