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
    
    private Rigidbody2D rb; //for Rigidbody
    public bool isGrounded; //kapag nagtapak si player sa ground
    public bool isMidAir;
    public bool isSkillActive;
    public bool isSkillUsed;

    private EmotionItemSkill emotionSkill; //reference ung EmotionItemSkill.cs
    private PlayerInventory playerInventory;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // for rigidbody
        playerInventory = GetComponent<PlayerInventory>();
        emotionSkill = GetComponent<EmotionItemSkill>();
    }

    void Update()
    {
        // Player movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (isGrounded)
            {
                Jump();
            }
            
            // Double jump skill
            if (isMidAir && isSkillActive)
            {
                Jump();
                Debug.Log("Double Jump");
                isSkillUsed = true;
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
        isMidAir = !isGrounded;
        
        if (isGrounded && isSkillActive && isSkillUsed)
        {
            isSkillActive = false;  // Reset skill after landing
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
