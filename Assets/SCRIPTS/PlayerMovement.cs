using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isGrounded;
    private Rigidbody2D rigidBody;
    
    void Start()
    {
      rigidBody = GetComponent<Rigidbody2D>();  
    }
    
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rigidBody.linearVelocity = new Vector2(moveInput * speed, rigidBody.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
