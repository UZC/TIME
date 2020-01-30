using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneModel : MonoBehaviour
{
    public static bool isArtiffactTaken;
    public Health player;
    public VictoryCondition victory;
    [SerializeField]
    public static SpriteRenderer sceneLight;

    public Text text;
    public Canvas can;

    void Start()
    {
        isArtiffactTaken = false;
        sceneLight = GameObject.Find("back").GetComponent<SpriteRenderer>();
        can.enabled = false;
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
        can.enabled = true;
        text.text = "Congratulation, you won!";
    }

    public void DefeatScreen()
    {
        can.enabled = true;
        text.text = "You died :(";
    }
    public void Restart()
    {
        SceneManager.LoadScene("vdmytrenko");
        Time.timeScale = 1;
        isArtiffactTaken = false;
    }
    public void CloseApp()
    {
        Application.Quit();
    }
}
