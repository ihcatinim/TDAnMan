using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacks : MonoBehaviour
{
    public AudioManager audioManager;
    public Animator animator;
    public Transform attackpoint;
    public float attackRange = 0.7f;
    public LayerMask enemylayers;
    public int atkdama = 20;
    public float attackrate = 2f;
    float nextattacktime = 0f;
        
    // Start is called before the first frame update
    void Start()
    {
        animator =GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();    
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)/* && Input.GetKeyDown(KeyCode.J)*/)
        {
            if(Time.time >= nextattacktime) {
                audioManager.PlaySFX(audioManager.kick1);
                animator.SetTrigger("kick1");
                attack();
                nextattacktime = Time.time + 1f / attackrate;
            }
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.K))
        {
                audioManager.PlaySFX(audioManager.kick2);
                animator.SetTrigger("kick2");
                attack();
                
           
        }

        if (Input.GetKeyDown(KeyCode.J)/* && Input.GetKeyDown(KeyCode.J)*/)
        {
            if (Time.time >= nextattacktime)
            {
                audioManager.PlaySFX(audioManager.punch1);
                animator.SetTrigger("punch1");
                attack();
                nextattacktime = Time.time + 1f / attackrate;
            }
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.J))
        {
            audioManager.PlaySFX(audioManager.punch2);
            animator.SetTrigger("punch2");
                attack();
            
        }
    }
    void attack()
    {
        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemylayers);
        foreach(Collider2D enemy in hitenemy)
        {
            enemy.GetComponent<enemy>().Takedame(atkdama);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}
