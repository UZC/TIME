using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
   
    public Transform player;
    public Transform moveSpot;

    public float attackDistance = 2f;
    public float detectRadius;
    public float moveSpeed = 5f;
    public float patrolSpeed = 4f;
    public float startWaitTime;
    
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    private float waitTIme;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        waitTIme = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
   
    private void FixedUpdate()
    {
        if(Vector3.Distance(player.position, transform.position) <=detectRadius)
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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

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
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTIme <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTIme = startWaitTime;
            }
            else
            {
                waitTIme -= Time.deltaTime;
            }
        }
    }
    
}
