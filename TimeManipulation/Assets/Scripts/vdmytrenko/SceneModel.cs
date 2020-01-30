using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneModel : MonoBehaviour
{
    public static bool isArtiffactTaken;
    public Health player;
    public VictoryCondition victory;

    void Start()
    {
        isArtiffactTaken = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.IsDead())
        {
            Time.timeScale = 0;
            DefeatScreen();
        }
        if (isArtiffactTaken && victory.GetCondition())
        {
            Debug.Log("pobeda");
            Time.timeScale = 0;
        }
    }
    public static void TakeArtiffact()
    {
        isArtiffactTaken = true;
    }

    public void VictoryScreen()
    {
            
    }

    public void DefeatScreen()
    {

    }
}
