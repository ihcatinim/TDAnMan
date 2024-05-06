using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public HealthbarMain healthbarMain;
    public Animator animator;
    public int maxhealth = 100;
    public int currenthp;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currenthp = maxhealth;
        healthbarMain.SetMaxhealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDame(int damage)
    {
        currenthp -= damage;
        Debug.Log(currenthp);
        healthbarMain.SetHealth(currenthp);
        animator.SetTrigger("hitted");
        if (currenthp <= 0)
        {

            Die();
        }
        void Die()
        {
            
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }

    }

    /*internal void TakeDame(float atkdamage)
    {
        throw new NotImplementedException();
    }*/
}