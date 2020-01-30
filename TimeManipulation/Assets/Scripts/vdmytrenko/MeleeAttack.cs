using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRange;
    public float attackCooldown;
    public Health player;
    public int damage;
    public float slowValue = 0.7f;
    public float slowRange = 1.5f;
    public float slowCooldown;

    float speedTemp;
    private bool onCooldown;

    private bool slowOnCd;
    void Start()
    {
        onCooldown = false;
        slowOnCd = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= attackRange)
            DoAttack();
        if (Input.GetKeyDown(KeyCode.E) && SceneModel.isArtiffactTaken)
            AOESlow();
    }

    private void AOESlow()
    {
        if (!slowOnCd)
        {
            player.GetComponent<Light>().enabled = true;
            StartCoroutine(Blim());
            slowOnCd = true;
            StartCoroutine(SlowCD());
            if (Vector2.Distance(this.transform.position, player.transform.position) <= slowRange)
            {
                this.GetComponent<EnemyAI>().moveSpeed *= slowValue;
            }
        }
    }
    private IEnumerator Blim()
    {
        yield return new WaitForSeconds(0.25f);
        player.GetComponent<Light>().enabled = false;
    }
    private IEnumerator SlowCD()
    {
        yield return new WaitForSeconds(slowCooldown);
        slowOnCd = false;
    }
    private void DoAttack()
    {
        if (!onCooldown && !player.IsDead())
        {
            speedTemp = this.GetComponent<EnemyAI>().moveSpeed;
            this.GetComponent<EnemyAI>().moveSpeed = 0;
            this.GetComponent<EnemyAnimation>().Attack();
            StartCoroutine(BeforeAttack());
            onCooldown = true;
            StartCoroutine(StartCoolDown());
        }
    }

    private IEnumerator StartCoolDown()
    {
        yield return new WaitForSeconds(attackCooldown);
        onCooldown = false;
        this.GetComponent<EnemyAI>().moveSpeed = speedTemp;
    }
    private IEnumerator BeforeAttack()
    {
        yield return new WaitForSeconds(0.7f);
        player.TakeDamage(damage);
    }
}
