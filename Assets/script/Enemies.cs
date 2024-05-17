using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public AudioManager audio;
    public Slider slider;
    public Animator animator;
    public int maxhealth = 100;
    public int currenthp;
    public Transform player;
    public bool isFlip = false;
    public void lookplayer()
    {
        Vector3 flip = transform.localScale;
        flip.z *= -1f;
        if (transform.position.x > player.position.x && isFlip)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlip = false;
        }
        if (transform.position.x < player.position.x && !isFlip)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlip = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
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
        audio.PlaySFX(audio.enemygethurt);
        currenthp -= damage;
        Debug.Log("AR"+currenthp);
        SetHealth(currenthp);
        animator.SetTrigger("hitted");
        if (currenthp <= 0)
        {
            
            Die();
        }
        void Die()
        {
            animator.SetBool("die",true);
            GetComponent<Collider2D>().isTrigger = true;
            

        }
        

    }
}
