using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletenemy : MonoBehaviour
{
    public float livetime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHP player = collision.GetComponent<playerHP>();
        if (player != null) {
            player.TakeDame(10);
        }
    }
}
