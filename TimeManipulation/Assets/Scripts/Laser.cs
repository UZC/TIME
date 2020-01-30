using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer _lineRend;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public float cooldown;
    [SerializeField]
    public float duration;
    private float nextActivity;
    private float currentTime = 0;
    [SerializeField]
    SkillCooldown sc;
    [SerializeField]
    MeleeAttack enemyAttack;


   

    //private void Update()
    //{

    //    _lineRend.SetPosition(0, new Vector2(10000, 10000));
    //    _lineRend.SetPosition(1, new Vector2(10000, 10000));
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        Ray2D ray = new Ray2D(transform.position, transform.up);
    //        RaycastHit2D hit2D = Physics2D.Raycast(player.transform.position + new Vector3(2f, 2f), ray.direction, 50f);
    //        _lineRend.SetPosition(0, player.transform.position);
    //        if (hit2D.collider)
    //        {
    //            Debug.Log(hit2D.collider.name);
    //            hit2D.transform.localScale = new Vector3(3.0f, 3.0f, 0.0f);
    //            enemyAttack.damage
    //        }
    //        Debug.Log(hit2D.point);
    //        _lineRend.SetPosition(1, new Vector2(player.transform.position.x, player.transform.position.y) + ray.direction * 50f);
    //    }
    //}

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            LaserStrike(new Vector3(2f, 2f));
    }
    public void LaserStrike(Vector3 Scale)
    {
       
        _lineRend = GetComponent<LineRenderer>();
        _lineRend.SetPosition(0, new Vector2(10000, 10000));
        _lineRend.SetPosition(1, new Vector2(10000, 10000));
        if (Time.time > nextActivity)
        {
            
                    Ray2D ray = new Ray2D(transform.position, transform.up);
                    RaycastHit2D hit2D = Physics2D.Raycast(player.transform.position + new Vector3(0f, 2f), ray.direction, 50f);
                    _lineRend.SetPosition(0, player.transform.position);
                    if (hit2D.collider)
                    {
                        hit2D.transform.localScale = Scale;
                        enemyAttack.damage = 1;
                    }
                    _lineRend.SetPosition(1, new Vector2(player.transform.position.x, player.transform.position.y) + ray.direction * 50f);
                    currentTime = currentTime + Time.deltaTime;
                    Debug.Log(currentTime);
                
                
                nextActivity = Time.time + cooldown;
                sc.StartCooldown(cooldown);


        }
    }
    IEnumerator Wait1second()
    {
        yield return new WaitForSeconds(1);
    }
}




