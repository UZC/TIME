using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    bool isDead;
    void Start()
    {
        isDead = false;
    }
    
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        this.health -= damage;
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
    }
    public bool IsDead()
    {
        return isDead;
    }
}
