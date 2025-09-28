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

    private Rigidbody2D rb; //for Rigidbody
    private bool isGrounded; //kapag nagtapak si player sa ground

    private EmotionItemSkill emotionSkill; //reference ung EmotionItemSkill.cs
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // for rigidbody
        
        emotionSkill = GetComponent<EmotionItemSkill>();
        if (emotionSkill == null)
        {
            
        }
    }

    void Update()
    {
        // Player movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jump Buffer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBuffer;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // Coyote Time Logic
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            if (emotionSkill != null)
            {
                emotionSkill.extraJump = emotionSkill.extraJumpValue;
            }
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Jump Logic
        if (jumpBufferCounter > 0f) // Normal ground jump
        {
            if (coyoteTimeCounter > 0f)
            {
                Jump();
                jumpBufferCounter = 0f;
            }
            
            else if (emotionSkill != null && emotionSkill.extraJump > 0)
            {
                Jump();
                emotionSkill.extraJump--;
                jumpBufferCounter = 0f;
            }
        }

        // Sprite Flip
        if (moveInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        //gravity increase after jump
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = 3f;
        }
    }

    // Keeps player from eternally jumping into space
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        coyoteTimeCounter = 0f;
    }
}
