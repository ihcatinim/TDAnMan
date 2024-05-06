using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator animator;
    public int maxhealth = 100;
    public int currenthp;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        currenthp = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDame(int damage)
    {
        currenthp -= damage;
        Debug.Log(currenthp);
        animator.SetTrigger("hitted");
        if (currenthp <= 0)
        {
            
            Die();
        }
        void Die()
        {
            animator.SetBool("die",true);
            GetComponent<Collider2D>().enabled = false; 
            this.enabled = false;
        }

    }
}
