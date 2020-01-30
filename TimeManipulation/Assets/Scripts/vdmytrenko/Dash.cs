using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float cooldown;
    public float distance;

    public KeyCode button;


    private bool isReady;
    void Start()
    {
        isReady = true;
    }
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(button))
        {
            UseDash();
        }
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldown);
        isReady = true;
    }

    public void UseDash()
    {
        if (isReady)
        {
            isReady = false;
            if (Input.GetKey(KeyCode.A))
                transform.position = new Vector2(this.transform.position.x - distance , this.transform.position.y);
            if (Input.GetKey(KeyCode.D))
                transform.position = new Vector2(this.transform.position.x + distance, this.transform.position.y);
            if (Input.GetKey(KeyCode.W))
                transform.position = new Vector2(this.transform.position.x, this.transform.position.y + distance);
            if (Input.GetKey(KeyCode.S))
                transform.position = new Vector2(this.transform.position.x, this.transform.position.y - distance);
            StartCoroutine(CoolDown());
        }
    }
}
