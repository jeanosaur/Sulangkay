using UnityEngine;
using System.Collections.Generic;
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
    public bool isMidAir; //player ay nasa air
    public bool isSkillActive; //magiging active kapag napress ung Z
    public bool isSkillUsed;

    private EmotionSkill emotionSkill; //reference ung EmotionItemSkill.cs
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // for rigidbody
        emotionSkill = GetComponent<EmotionSkill>(); //for using skill emotions
        animator = GetComponent<Animator>(); //for animation
    }

    private void Update()
    {
        // Toggle skill with Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isSkillActive = !isSkillActive;
        }
        
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
            else if (isMidAir && isSkillActive && !isSkillUsed)
            {
                Jump();
                isSkillUsed = true;
                Debug.Log("Double Jump");
               
            }
        }
        
        //Sprite Flip
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
        
        // Animation parameters
        animator.SetBool("isRunning", moveInput != 0);
        animator.SetBool("isJumping", !isGrounded);
	
    }

    // Keeps player from eternally jumping into space
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        isMidAir = !isGrounded;
        
        if (isGrounded)
        {
            isSkillUsed = false;  // Reset skill 
        }
    }

    private void Jump() //For Jump
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        
    }
}
