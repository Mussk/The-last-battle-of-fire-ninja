using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireSiphon : MonoBehaviour, IHasCooldown, IDealDamage
{

    public bool isSiphoning = false;

    [Header("Settings")]
    [SerializeField]
    private int id = 3;
    [SerializeField]
    private float cooldownDuration = 7.0f;

    public int Id => id;

    public float CooldownDuration => cooldownDuration;

    private int _damageAmount;

    public int DamageAmount => _damageAmount;


    // Start is called before the first frame update
    void Start()
    {
        _damageAmount = 30;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator StartSiphon(float duration)
    {
        gameObject.SetActive(true);
        isSiphoning = true;
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
        isSiphoning = false;
        gameObject.GetComponentInParent<PlayerController>().isCastingSkill = false;
        gameObject.GetComponentInParent<PlayerAnimationHandler>().StopSiphonAnimation();
    }

}
