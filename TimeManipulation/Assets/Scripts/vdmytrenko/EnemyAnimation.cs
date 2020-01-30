using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject idle;
    public GameObject left;
    public GameObject right;
    public GameObject attack;
    public GameObject death;
    void Start()
    {
        Idle();
    }

    // Update is called once per frame
    void Update()
    {
    }



    public void Right()
    {
        idle.SetActive(false);
        left.SetActive(false);
        right.SetActive(true);
        attack.SetActive(false);
        death.SetActive(false);
    }

    public void Left()
    {
        idle.SetActive(false);
        left.SetActive(true);
        right.SetActive(false);
        attack.SetActive(false);
        death.SetActive(false);
    }

    public void Idle()
    {
        idle.SetActive(true);
        left.SetActive(false);
        right.SetActive(false);
        attack.SetActive(false);
        death.SetActive(false);
    }
    public void Death()
    {
        idle.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        attack.SetActive(false);
        death.SetActive(true);
    }
    public void Attack()
    {
        idle.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        attack.SetActive(true);
        death.SetActive(false);
    }
}
