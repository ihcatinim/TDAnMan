using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public Slider slider;
    public Animator animator;
    public int maxhealth = 100;
    public int currenthp;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        currenthp = maxhealth;
        SetMaxhealth(currenthp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxhealth(int maxhealth)
    {
        slider.maxValue = maxhealth;
        slider.value = maxhealth;
    }
    public void Takedame(int damage)
    {
        currenthp -= damage;
        Debug.Log(currenthp);
        SetHealth(currenthp);
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
