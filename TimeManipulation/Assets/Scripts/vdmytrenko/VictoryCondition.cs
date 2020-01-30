using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    public Health player;
    bool isPlayerNear;

    void Start()
    {
        isPlayerNear = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) <= 1)
            isPlayerNear = true;
        else
            isPlayerNear = false;
    }

    public bool GetCondition()
    {
        return isPlayerNear;
    }
}
