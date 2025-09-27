using UnityEngine;
using System.Collections; // Needed for IEnumerator

public class Player : MonoBehaviour
{
    //Player movement variables 
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    
    // Player jump refinement
    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;
    public float jumpBuffer = 0.2f;
    public float jumpBufferCounter;

    private Rigidbody2D rb;
    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // for rigidbody 
    }

    void Update()
    {
        // Player movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Player jump
        if (jumpBufferCounter > 0f)
        {
            if (coyoteTimeCounter > 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                coyoteTimeCounter = 0f;
                jumpBufferCounter = 0f;
            }
        }
        
        // Coyote Time Logic
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        
        // Jump Buffer Logic 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBuffer;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // Sprite Flip
        if (moveInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (moveInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    // Keeps player from eternally jumping into space
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
