using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Text cointext;
    public float speed = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private Vector2 movement;
    private bool facingRight = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    public int coincount;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
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
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
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
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
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
            Destroy(other.gameObject);
            coincount += 1; 
        }
    }
    

}

