using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayChanging : MonoBehaviour
{
    public float daytimeReload = 60;
    public float daytimeDuration = 10;
    public float currentTime = 0;
    public Image abilityImage;
    public Text readyText;
    bool dayFlag;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage.fillAmount = currentTime;
        readyText.enabled = false;
        dayFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < daytimeReload && dayFlag)
        {
            currentTime = currentTime  + Time.deltaTime ;
            abilityImage.fillAmount = currentTime / daytimeReload;
        }
        else
        {
            if (dayFlag)
            {
                readyText.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UseAbility();
            }
            if (!dayFlag)
            {
                currentTime = currentTime - Time.deltaTime;
                abilityImage.fillAmount = currentTime / daytimeDuration;
                
                if (currentTime < 0)
                {
                    currentTime = 0;
                    dayFlag = true;
                }
            }
              
        }
        
    }

    private void FixedUpdate()
    {
        
    }

    void UseAbility()
    {
        readyText.enabled = false;
        dayFlag = false;
        currentTime = daytimeDuration;

    }

    

}
