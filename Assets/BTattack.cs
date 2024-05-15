using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTattack : MonoBehaviour
{
    public float attackrate = 2f;
    float nextattacktime = 0f;
    public AudioManager audio;
    public LayerMask layerplayer;
    public Transform attackpoint;
    public float attackrange;
    public Animator anim;
    public float attkdamage = 10;
    public Transform player;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(rb.position, player.position) <= attackrange)
        {
            if (Time.time >= nextattacktime)
            {

                attack();
                nextattacktime = Time.time + attackrate;
            }

        }
    }
    void attack()
    {
        audio.PlaySFX(audio.punch1);
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
