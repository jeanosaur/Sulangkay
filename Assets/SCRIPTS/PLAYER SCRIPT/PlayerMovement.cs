using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float horizontal;
    public float speed = 8f;
    public float jumpForce = 16f;
    public bool isFacingRight = true;

    [Header("Jump Forgiveness")]
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [Header("Jump Buffer")]
    public float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [Header("Jump Fall Settings")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Rigidbody and Ground")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Double Jump Settings")]
    [SerializeField] public bool doubleJumpEnabled = false;
    private bool canDoubleJump = false;
    private bool doubleJumpActive = false;
    private float doubleJumpTimer = 0f;
    [SerializeField] public float doubleJumpDuration = 2f;
    [SerializeField] public float doubleJumpCooldown = 5f;
    private float cooldownTimer = 0f;
    private bool onCooldown = false;
    [SerializeField] public float doubleTapTime = 0.3f;
    private float lastJumpTapTime = -1f;
    private bool jumpTappedOnce = false;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Activation of double jump mode using Alpha1 key
        if (!onCooldown && Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateDoubleJump();
        }

        // Timer for active double jump state
        if (doubleJumpActive)
        {
            doubleJumpTimer -= Time.deltaTime;
            if (doubleJumpTimer <= 0f)
            {
                doubleJumpActive = false;
                StartDoubleJumpCooldown();
            }
        }

        // Cooldown timer
        if (onCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                onCooldown = false;
            }
        }

        // Coyote time logic
        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            canDoubleJump = true; // reset double jump on landing
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Jump buffer logic
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;

            // Double-tap detection
            if (jumpTappedOnce && (Time.time - lastJumpTapTime) <= doubleTapTime)
            {
                TryDoubleJump();
                jumpTappedOnce = false;
            }
            else
            {
                jumpTappedOnce = true;
                lastJumpTapTime = Time.time;
            }
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // Normal jump with coyote time and jump buffer 
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpBufferCounter = 0f;
        }

        // Short jump cut
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }

        // For fall and low jump multipliers
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool isGrounded() //check if nasa ground si player
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // Called when pressed 1
    private void ActivateDoubleJump()
    {
        doubleJumpActive = true;
        doubleJumpTimer = doubleJumpDuration;
    }

    // Cooldown of double 
    private void StartDoubleJumpCooldown()
    {
        onCooldown = true;
        cooldownTimer = doubleJumpCooldown;
    }

    // Try to double jump (triggered by double-tap)
    private void TryDoubleJump()
    {
        if (doubleJumpActive && canDoubleJump && !isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            canDoubleJump = false; // only once
        }
    }
}
