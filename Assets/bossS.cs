using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossS : MonoBehaviour
{
    public int defeated1 = 0;
    public int defeated2 = 0;
    public AudioManager Audio;
    public Slider slider;
    public Animator animator;
    public int maxhealth = 100;
    public int currenthp;
    
    public Transform playerr;
    public bool isflip = false;
    void Start()
    {
        Audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
        currenthp = maxhealth;
        SetMaxhealth(currenthp);
    }
    void Update()
    {

    }
    public void LookatPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x > playerr.position.x && isflip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isflip = false;
        }
        if (transform.position.x < playerr.position.x && !isflip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isflip = true;
        }
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
        Audio.PlaySFX(Audio.enemygethurt);
        currenthp -= damage;
        Debug.Log( + currenthp);
        SetHealth(currenthp);
        
        if (currenthp <= 0)
        {

            //Die();
        }
    }
}
