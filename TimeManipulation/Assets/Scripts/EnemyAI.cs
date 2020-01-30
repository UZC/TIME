using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{

    public Transform player;
    private Vector2 moveSpot;

    public float attackDistance = 2f;
    public float detectRadius;
    public float moveSpeed = 5f;
    public float patrolSpeed = 4f;
    public float startWaitTime;

    public float maxX;
    public float maxY;

    bool readyForBoost;

    private float waitTIme;
    private Rigidbody2D rb;
    private Vector2 movement;
    Vector2 startPos;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        waitTIme = startWaitTime;
        startPos = new Vector2(this.transform.position.x, this.transform.position.y);
        moveSpot = new Vector2(Random.Range(startPos.x - maxX, startPos.x + maxX),
            Random.Range(startPos.y - maxY, startPos.y + maxY));
        readyForBoost = true;
    }

    private void FixedUpdate()
    {
        if (readyForBoost  && SceneModel.isArtiffactTaken)
        {
            readyForBoost = false;
            detectRadius *= 2;
            patrolSpeed *= 1.5f;
            moveSpeed *= 1.3f;
            maxX *= 2.5f;
            maxY *= 2.5f;
            this.GetComponent<MeleeAttack>().damage = 20;
            this.GetComponent<Light>().range *= 2;
        }
        if (Vector3.Distance(player.position, transform.position) <= detectRadius)
        {
            if (Vector3.Distance(player.position, transform.position) >= attackDistance)
            {
                RotateToPlayer();
                MoveCharacter(movement);
            }
            else
                AttackCharacter();

        }
        else
        {
            Patroling();
        }
    }
    void RotateToPlayer()
    {
        Vector2 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        if (moveSpeed > 0.01f)
        {
            if (player.position.x < transform.position.x)
                this.GetComponent<EnemyAnimation>().Left();
            else
                this.GetComponent<EnemyAnimation>().Right();
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void AttackCharacter()
    {

    }

    void Patroling()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, patrolSpeed * Time.deltaTime);
        if (moveSpeed >= 0.01f)
        {
            if (moveSpot.x < transform.position.x)
                this.GetComponent<EnemyAnimation>().Left();
            else
                this.GetComponent<EnemyAnimation>().Right();
        }

        if (Vector2.Distance(transform.position, moveSpot) < 0.2f)
        {
            if (waitTIme <= 0)
            {
                moveSpot = new Vector2(Random.Range(startPos.x - maxX, startPos.x + maxX),
                Random.Range(startPos.y - maxY, startPos.y + maxY));
                waitTIme = startWaitTime;
            }
            else
            {
                waitTIme -= Time.deltaTime;
                this.GetComponent<EnemyAnimation>().Idle();
            }
        }
    }


}
