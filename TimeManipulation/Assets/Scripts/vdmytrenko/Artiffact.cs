using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artiffact : MonoBehaviour
{

    public Health player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) <= 0.7f)
        {
            TakeArtiffact();
        }
    }

    private void TakeArtiffact()
    {
        SceneModel.TakeArtiffact();
        Destroy(this.gameObject);
    }
}
