using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireSiphon : MonoBehaviour, IHasCooldown, IDealDamage
{

    public bool isSiphoning = false;

    [Header("Settings")]
    [SerializeField]
    private int id;
    [SerializeField]
    private float cooldownDuration;

    public int Id => id;

    public float CooldownDuration => cooldownDuration;

    [SerializeField]
    private int _damageAmount;

    public int DamageAmount => _damageAmount;


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
