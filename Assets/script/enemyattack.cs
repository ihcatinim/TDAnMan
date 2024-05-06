using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    public LayerMask layerplayer;
    public Transform attackpoint;
    public float attackrange;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("0"))
        {
            attack();
        }
    }
    void attack()
    {
        
        anim.SetTrigger("attack");
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, layerplayer);

    }
}
