using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillCooldownUI : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private CooldownSystem playerCooldownSystem;

    public List<Image> skillIcons;

    public List<TextMeshProUGUI> skillColldownsTexts;


    // Start is called before the first frame update
    void Start()
    {
        playerCooldownSystem = player.gameObject.GetComponent<CooldownSystem>();

        skillIcons.ForEach(e => e.fillAmount = 0);

        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUICooldown();
    }

    public void StartUICooldown(int id) 
    {
        
        skillIcons[id - 1].fillAmount = 1;
        skillColldownsTexts[id-1].gameObject.SetActive(true);
        skillColldownsTexts[id - 1].text = playerCooldownSystem.cooldowns.Find(e => e.Id == id)
            .initialDuration.ToString();
    }

    public void UpdateUICooldown()
    {

        if (playerCooldownSystem.cooldowns.Count > 0)
        {
            playerCooldownSystem.cooldowns.ForEach(e =>
            {
                Image image = skillIcons[e.Id - 1];

                TextMeshProUGUI textField = skillColldownsTexts[e.Id - 1];

                image.fillAmount -= 1 / e.initialDuration * Time.deltaTime;

                textField.text = e.RemainingTime.ToString("0.00");

                if (e.RemainingTime <= 0.1f)
                {
                    
                    textField.text = e.KeyboardKey.ToString();

                    image.fillAmount = 0;

                }

            });
        }
    }   
}
