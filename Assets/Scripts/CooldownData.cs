using UnityEngine;


public class CooldownData
{   

    public int Id { get; }
    public float RemainingTime { get; private set; }

    public float initialDuration;

    public KeyCode KeyboardKey { get; }
    
    public CooldownData(IHasCooldown cooldown)
    {
        
        Id = cooldown.Id;
        RemainingTime = cooldown.CooldownDuration;
        initialDuration = cooldown.CooldownDuration;
        KeyboardKey = cooldown.KeyboardKey;
    }

    public bool DecrementCooldown(float deltaTime)
    {

        RemainingTime = Mathf.Max(RemainingTime - deltaTime, 0f);

        return RemainingTime == 0f;

    }
}
