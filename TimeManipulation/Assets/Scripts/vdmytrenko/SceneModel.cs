using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneModel : MonoBehaviour
{
    public static bool isArtiffactTaken;
    public Health player;
    public VictoryCondition victory;
    [SerializeField]
    public static SpriteRenderer sceneLight;

    void Start()
    {
        isArtiffactTaken = false;
        sceneLight = GameObject.Find("back").GetComponent<SpriteRenderer>();
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
            Time.timeScale = 0;
            VictoryScreen();
        }
    }
    public static void TakeArtiffact()
    {
        isArtiffactTaken = true;
        sceneLight.color = new Color(0.5f, 0.5f, 0.5f);
    }

    public void VictoryScreen()
    {
            
    }

    public void DefeatScreen()
    {

    }
}
