using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    float _currentHealth;
    float _currentMaxHealth;

    AnimationHandler _animationHanlder;

    private Healthbar _healthbar;

    private float DoTSpeedMOdifier = 0.5f;

    public float currentHealth
    { 
        get 
        { 
            return _currentHealth;
        }
        set 
        { 
        
            _currentHealth = value;

        }
    }

    public float currentMaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {

            _currentMaxHealth = value;

        }
    }

    public HealthSystem(int currentHealth, int currentMaxHealth, AnimationHandler animationHanlder, Healthbar healthbar)
    {

        _currentHealth = currentHealth;
        _currentMaxHealth = currentMaxHealth;
        _animationHanlder = animationHanlder;
        _healthbar = healthbar;
        _healthbar.UpdateHealthBar(_currentMaxHealth,_currentHealth);
    }


    /**
     * 
     * value can take positive and negative values
     * 
     * **/
    public void ChangeHealth(int value) 
    {
       
        _currentHealth += value;

        DamagePostprocessing();
    }

    public void ChangeHealthOvertime(int value) 
    {
        _currentHealth = Mathf.MoveTowards(_currentHealth, _currentHealth + value, DoTSpeedMOdifier);

        DamagePostprocessing();
        
    }

    //check health within [0, maxhealth], update healthbar & death state
    private void DamagePostprocessing() 
    {
       
        //check if health >= 0
        _currentHealth = Mathf.Max(0, _currentHealth);

        //check if health <= maxHealth
        _currentHealth = Mathf.Min(_currentHealth, _currentMaxHealth);

        _healthbar.UpdateHealthBar(_currentMaxHealth, _currentHealth);

        if (_animationHanlder.gameObject.CompareTag("Player") 
            && _currentHealth > 0) 
        {

            CoinsManager.Instance.CoinsAmountThisGame = CoinsManager.Instance.
            ChangeCoinsAmount(CoinsManager.Instance.CoinsAmountThisGame,
            -CoinsManager.Instance.CoinsRemovedOnDamageTaken);
        
        }

        if (_currentHealth == 0)
        {
           
            _animationHanlder.PlayDeathAnimation();

        }
    }
}
