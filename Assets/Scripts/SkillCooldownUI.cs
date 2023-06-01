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

        //playerCooldownSystem.cooldowns.ForEach(e => e.UIcon.fillAmount = 0);

        skillIcons.ForEach(e => e.fillAmount = 0);

        skillColldownsTexts.ForEach(e => e.gameObject.SetActive(false));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUICooldown();
    }

    public void StartUICooldown(int id) 
    {
        
        skillIcons[id - 2].fillAmount = 1;
        skillColldownsTexts[id-2].gameObject.SetActive(true);
        skillColldownsTexts[id - 2].text = playerCooldownSystem.cooldowns.Find(e => e.Id == id)
            .initialDuration.ToString();
    }

    public void UpdateUICooldown()
    {

        if (playerCooldownSystem.cooldowns.Count > 0)
        {
            playerCooldownSystem.cooldowns.FindAll(e => e.Id > 1).ForEach(e =>
            {
                Image image = skillIcons[e.Id - 2];

                TextMeshProUGUI textField = skillColldownsTexts[e.Id - 2];

                image.fillAmount -= 1 / e.initialDuration * Time.deltaTime;

                textField.text = e.RemainingTime.ToString("0.00");

                if (e.RemainingTime <= 0.1f)
                {
                  textField.gameObject.SetActive(false);
                 image.fillAmount = 0;

                }

            });
        }
    }   
}
