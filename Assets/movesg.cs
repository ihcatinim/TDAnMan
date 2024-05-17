using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class movesg : StateMachineBehaviour
{
    public GameObject bullet;
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
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(rb.position, player.position) <= 8)
        {
            animator.GetComponent<enemy>().lookplayer();
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newP = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newP);
        }
        /*if (Vector2.Distance(rb.position, player.position) <= attackrange)
        {
            animator.SetTrigger("attack");
            animator.GetComponent<attackSG>().att



        }*/
        /*void attack(){
            Instantiate(bullet, attackpoint.position, attackpoint.rotation);
        }*/
        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
