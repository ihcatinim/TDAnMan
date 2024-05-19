using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public controllUi controllui;
    public AudioManager manager;
    public HealthbarMain healthbarMain;
    public Animator animator;
    public int maxhealth = 100;
    public int currenthp;
    // Start is called before the first frame update
    void Start()
    {
        
        manager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
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
        manager.PlaySFX(manager.maingethurt);
        currenthp -= damage;
        Debug.Log(currenthp);
        healthbarMain.SetHealth(currenthp);
        animator.SetTrigger("hitted");
        if (currenthp <= 0)
        {
            controllui.gameOver();
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