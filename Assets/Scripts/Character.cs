using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IHasHealth
{
    [SerializeField]
    public bool isMoving = true;

    [SerializeField]
    public SFXSoundManager SFXManager;

    protected HealthSystem healthSystem;

    [SerializeField]
    protected int _currentHealth;

    [SerializeField]
    protected int _currentMaxHealth;

    public int CurrentHealth => _currentHealth;
   
    public int CurrentMaxHealth => _currentMaxHealth;

    public HealthSystem HealthSystem { get => healthSystem; set => healthSystem = value; }

    void Start()
    {
        isMoving = true;
    }

}
