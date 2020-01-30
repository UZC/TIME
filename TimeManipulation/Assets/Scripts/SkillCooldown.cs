using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    float cooldown;
    float currentCooldown = 0;
    public Image cooldownIcon;
    bool flagStart = false;
    void Update()
    {
        if (flagStart)
        {
            if (currentCooldown >= cooldown)
            {
                cooldownIcon.fillAmount = 0;
                flagStart = false;
                currentCooldown = 0;
            }
            if (currentCooldown < cooldown)
            {
                currentCooldown += Time.deltaTime;
                cooldownIcon.fillAmount = currentCooldown / cooldown;
            }
        }
    }
    public void StartCooldown(float cooldown)
    {
        this.cooldown = cooldown;
        flagStart = true;
    }
}
