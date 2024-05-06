using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public Transform[] movepoints;
    public float speed ;
    public int pointdestination;
    public Animator animator;
    private Vector2 movement;
    private bool facingRight = true;
    private bool ischasing = false;
    public Transform playertranform ;
    public float distance;
    public float chasespeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {

        if (ischasing)
        {
            if (transform.position.x > playertranform.position.x)
            {
                transform.position += Vector3.left * chasespeed * Time.deltaTime;
            }
            if (transform.position.x < playertranform.position.x)
            {
                transform.position += Vector3.right * chasespeed * Time.deltaTime;
            }

        }
        else
        {
            if (Vector2.Distance(transform.position, playertranform.position) < distance)
            {
                ischasing = true;
            }
        }
        /* movement.x = Input.GetAxis("horizontal") ;*/

        if (movement.x > 0 && !facingRight)
        {
            animator.SetBool("move", true);
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            animator.SetBool("move", true);
            Flip();
        }
        if (pointdestination == 0)
        {
           transform.position = Vector2.MoveTowards(transform.position, movepoints[0].position, speed*Time.deltaTime);
           
           if(Vector2.Distance(transform.position, movepoints[0].position) < .2f)
            {
                pointdestination = 1;
            }  
        }
        if (pointdestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, movepoints[1].position, speed*Time.deltaTime);
            if (Vector2.Distance(transform.position, movepoints[1].position) < .2f)
            {
                pointdestination = 0;
            }

        
        }
        void Flip()
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
