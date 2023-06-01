using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownData
{   

    public int Id { get; }
    public float RemainingTime { get; private set; }

    public float initialDuration;
    
    public CooldownData(IHasCooldown cooldown)
    {

        Id = cooldown.Id;
        RemainingTime = cooldown.CooldownDuration;
        initialDuration = cooldown.CooldownDuration;
    }

    public bool DecrementCooldown(float deltaTime)
    {

        RemainingTime = Mathf.Max(RemainingTime - deltaTime, 0f);

        return RemainingTime == 0f;

    }
}
