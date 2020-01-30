using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimationsController : MonoBehaviour
{
    public Animator anim;


    public void PlayAnimation()
    {
        anim = GetComponent<Animator>();
        
    }
    


// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("PLaying animation...");
            anim.Play("Idle_0", 0, 0.25f);
        }
    }
}
