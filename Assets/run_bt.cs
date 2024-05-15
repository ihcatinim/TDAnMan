using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class run_bt : StateMachineBehaviour
{
    public float attackrate = 2f;
    float nextattacktime = 0f;
    public AudioManager audio;
    public LayerMask layerplayer;
    public Transform attackpoint;
    public float attackrange;
    public Animator anim;
    public float attkdamage = 10;

    public Rigidbody2D rb;
    public float speed = 2.5f;
    Transform player;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player =  GameObject.FindGameObjectWithTag("Player").transform;
        rb =  animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(rb.position, player.position) <= 8)
        {
            animator.GetComponent<Batonenemy>().lookplayer();
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newP = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newP);
        }
        /*else if (Vector2.Distance(rb.position, player.position) > 8)
        {
            animator.SetBool("move", false); 
        }*/


        if (Vector2.Distance(rb.position, player.position) <= attackrange)
        {
            attack();



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
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
