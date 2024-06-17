using System.Collections.Generic;
using UnityEngine;

public class CooldownSystem : MonoBehaviour
{
    public List<CooldownData> cooldowns = new List<CooldownData>();

    private void Update()
    {
        ProcessCooldown();
        
    }


    public void PutOnCooldown(IHasCooldown cooldown)
    {
        
        cooldowns.Add(new CooldownData(cooldown));
        
    }

    public bool IsOnCooldown(int id)
    {

        foreach(CooldownData cooldown in cooldowns) 
        { 
        
            if(cooldown.Id == id) { return true; }

        }

        return false;
    }

    public float GetRemainingDuration(int id)
    {

        foreach (CooldownData cooldown in cooldowns)
        {

            if (cooldown.Id != id) { continue; }

            return cooldown.RemainingTime;
        }

        return 0f;
    }


    private void ProcessCooldown()
    {
        float deltaTime = Time.deltaTime;

        for (int i = cooldowns.Count - 1; i >= 0; i--)
        {
            if (cooldowns[i].DecrementCooldown(deltaTime)) 
            { 
                
                cooldowns.RemoveAt(i);

            }
        }

    }
}
