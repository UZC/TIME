using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRange;
    public float attackCooldown;
    public Health player;
    public int damage;


    private bool onCooldown;
    void Start()
    {
        onCooldown = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= attackRange)
            DoAttack();
    }

    private void DoAttack()
    {
        if (!onCooldown && !player.IsDead())
        {
            player.TakeDamage(damage);
            onCooldown = true;
            StartCoroutine(StartCoolDown());
        }
    }

    private IEnumerator StartCoolDown()
    {
        yield return new WaitForSeconds(attackCooldown);
        onCooldown = false;
    }
}
