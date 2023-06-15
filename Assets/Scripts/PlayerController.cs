using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerController : Character, IShootable, IHasHealth
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _model;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed;
    [SerializeField] Camera _camera;
    
    private Vector3 _input;

    public Vector3 PlayerInput => _input;

    [SerializeField]
    private PlayerProjectile dagger;

    [SerializeField]
    private Fireball fireball;

    [SerializeField]
    private Firestorm firestorm;

    [SerializeField]
    private FireSiphon fireSiphon;

    
    public bool isCastingSkill;

    [SerializeField]
    private CooldownSystem cooldownSystem;

    [SerializeField]
    private SkillCooldownUI skillCooldownUI;

    [SerializeField]
    private int _currentHealth;

    [SerializeField]
    private int _currentMaxHealth;

    public int CurrentHealth => _currentHealth;

    public int CurrentMaxHealth => _currentMaxHealth;

    [SerializeField]
    public HealthSystem healthSystem;

    [SerializeField]
    private Healthbar healthbar;

    [SerializeField]
    private LayerMask layermask;

    [SerializeField]
    private Transform projectilesSpawner;

    [SerializeField]
    private PlayerAnimationHandler playerAnimationHandler;

    [SerializeField]
    public AnimationHandler animationHandler;

    [field: SerializeField]
    public int CoinsCount { get; set; }


    void Awake() 
    {
        layermask |= (1 << 3);

        layermask = ~layermask;

        healthSystem = new HealthSystem(_currentHealth, _currentMaxHealth, animationHandler, healthbar);

    }

    // Start is called before the first frame update
    void Update()
    {
        if (healthSystem.currentHealth > 0 && !PauseMenu.IsPaused) {
            
            GatherInput();
            Look();
            //better to separate Shoot() in other script
            if(SceneManager.GetActiveScene().buildIndex == 0)
                Shoot();
            
        }
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move();

        }
    }

private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    }

    private void Look()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f, layermask)) 
        {

            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);

           
        }

    }

    private void Move()
    {
        _rb.MovePosition(transform.position + _input.ToIso() * _input.normalized.magnitude * _speed * Time.deltaTime);

    }

    //invokes directly from animation, doesn't allow to use other skills while casting
    public void PreventAnimationInterruptionEvent()
    { 
    
        isCastingSkill = true;
    
    }


    //invokes directly from animation (except fire siphon), allows to use other skills
    //for fir siphon check 
    public void EndOfAnimationEvent()
    {

        isCastingSkill = false;

    }


    //this method is invoked by animation PunchRight
    public void ThrowDaggerAnimationEvent()
    {
        
        Instantiate(dagger, projectilesSpawner.position, transform.rotation);

    }


    //this method is invoked by animation SpellCast
    public void CastFireballAnimationEvent()
    {

        Instantiate(fireball, projectilesSpawner.position, transform.rotation);

    }

    public void CastFirestormAnimationEvent()
    {

        Instantiate(firestorm, transform.position, transform.rotation);

    }

    public void Shoot() 
    {
        if (!isCastingSkill) {         
            
            if (Input.GetKeyDown(KeyCode.Space)) {

                
                if (cooldownSystem.IsOnCooldown(dagger.Id)) { return; }

                playerAnimationHandler.PlayDaggerThrowAnimation();

                cooldownSystem.PutOnCooldown(dagger);
         
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (cooldownSystem.IsOnCooldown(fireball.Id)) { return; }

                playerAnimationHandler.PlayFireballAnimation();

                cooldownSystem.PutOnCooldown(fireball);
                skillCooldownUI.StartUICooldown(fireball.Id);

            }

            if (Input.GetKeyDown(KeyCode.E)) 
            {
                
                if (cooldownSystem.IsOnCooldown(fireSiphon.Id)) { return; }

                isCastingSkill = true;

                if (!fireSiphon.isSiphoning) 
                { 
                    playerAnimationHandler.PlaySiphonCastAnimation();

                    StartCoroutine(fireSiphon.StartSiphon(5.0f));

                }

                cooldownSystem.PutOnCooldown(fireSiphon);
                skillCooldownUI.StartUICooldown(fireSiphon.Id);

            }

            if (Input.GetKeyDown(KeyCode.R))
            {

                if (cooldownSystem.IsOnCooldown(firestorm.Id)) { return; }

                playerAnimationHandler.PlayFirestormAnimation();
                  
                cooldownSystem.PutOnCooldown(firestorm);
                skillCooldownUI.StartUICooldown(firestorm.Id);
            }

            
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            healthSystem.ChangeHealth(-other.gameObject.GetComponent<Enemy>().DamageAmount);
        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {

            healthSystem.ChangeHealth(-other.gameObject.GetComponent<Projectile>().DamageAmount);

        }

        if (other.gameObject.CompareTag("EnemyWeapon"))
        {

            healthSystem.ChangeHealth(-other.gameObject.GetComponentInParent<Enemy>().DamageAmount);
        
        }
    }
}


