using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Batonenemy : MonoBehaviour
    
{
    public Transform player;
    public bool isFlip = false;
    public void lookplayer()
    {
        Vector3 flip = transform.localScale;
        flip.z *= -1f;
        if(transform.position.x>player.position.x&& isFlip)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlip = false;
        }
        if(transform.position.x < player.position.x && !isFlip)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlip = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
