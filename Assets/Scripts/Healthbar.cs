using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Image _healthBarFiller;

    [SerializeField]
    private float _reduceSpeed = 2;

    private float _target = 1;

    //not Camera type because main camera is nested in other GameObject (because isometric)
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        
    }

    private void LateUpdate()
    {
        transform.rotation = _camera.transform.rotation;
        _healthBarFiller.fillAmount = Mathf.MoveTowards(_healthBarFiller.fillAmount,
            _target, _reduceSpeed * Time.deltaTime);
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;
    }

    
}
