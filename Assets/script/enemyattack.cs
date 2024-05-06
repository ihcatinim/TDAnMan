using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    public LayerMask layerplayer;
    public Transform attackpoint;
    public float attackrange;
    public Animator anim;
    public float attkdamage=10;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.P))
        {
            attack();
        }
    }
    void attack()
    {
        
        anim.SetTrigger("attack");
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, layerplayer);
        foreach (Collider2D player in hitplayer)
        {
            player.GetComponent<playerHP>().TakeDame((int)attkdamage);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
