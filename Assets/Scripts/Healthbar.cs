using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : WorldSpaceUI
{
    
    private Image _healthBarFiller;

    [SerializeField]
    private float _reduceSpeed = 2;

    private float _target = 1;

    protected override void Awake()
    {
        _healthBarFiller = uiObject.GetComponent<Image>();

        base.Awake();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        _healthBarFiller.fillAmount = Mathf.MoveTowards(_healthBarFiller.fillAmount,
            _target, _reduceSpeed * Time.deltaTime);
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;
    }

    
}
