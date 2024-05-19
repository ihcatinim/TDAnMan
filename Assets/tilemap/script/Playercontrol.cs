using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public AudioManager manager;
    public Text cointext;
    public float speed = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    public float jumpForce = 10f;

    private Vector2 movement;
    private bool facingRight = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    public int coincount;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        // Input
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        if (movement.x > 0 && !facingRight)
        {
            animator.SetBool("run", true);
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            animator.SetBool("run", true);
            Flip();
        }
        movement = movement * speed;
        if (/*isGrounded &&*/ Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("move up");
            movement.y = jumpForce;
            animator.SetTrigger("jump");
        }
        if (movement.normalized.magnitude > 0)
        {
            Debug.Log($"velocity: {movement}");
            if (movement.y == 0)
                movement.y = rb.velocity.y;
            rb.velocity = movement;
        }

        /*if (rb.velocity.y < 0)
        {
           
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("jump");
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }*/
        cointext.text = coincount.ToString();
    }

    void FixedUpdate()
    {
        // Movement
        // rb.MovePosition(rb.position + movement * speed);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            manager.PlaySFX(manager.collectcoin);
            Destroy(other.gameObject);
            coincount += 1;
        }
    }


}

