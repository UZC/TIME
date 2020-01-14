using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool movementFlag=true;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 direction = player.position - transform.position;
            Debug.Log(Vector3.Distance(player.position, transform.position));
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) >= 2)
            moveCharacter(movement);
        else
            attackCharacter();
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));      
    }
    void attackCharacter()
    {

    }
}
