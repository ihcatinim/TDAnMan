using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTenemy : MonoBehaviour
{
    public AudioManager audio;
    public Slider slider;
    public Animator animator;
    public int maxhealth = 100;
    public int currenthp;
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
        Debug.Log("BT" +currenthp);
        SetHealth(currenthp);
        animator.SetTrigger("hitted");
        if (currenthp <= 0)
        {

            Die();
        }
        void Die()
        {
            animator.SetBool("die", true);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }

    }
}
