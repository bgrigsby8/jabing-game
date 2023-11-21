using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool isGrounded;
    public float jumpForce = 8f;
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        // Handles moving the player along the x-axis
        float xDirection = Input.GetAxis("Horizontal");
        Vector2 moveVector = new Vector2(xDirection * moveSpeed, rb.velocity.y);
        rb.velocity = moveVector;

        if (xDirection > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (xDirection < 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void Jump()
    {
        // Handles jumping the player
        Vector2 jumpVector = new Vector2(0F, jumpForce);
        rb.AddForce(jumpVector, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
