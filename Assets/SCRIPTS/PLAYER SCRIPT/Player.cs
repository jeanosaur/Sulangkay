using UnityEngine;
using System.Collections; // Needed for IEnumerator

public class Player : MonoBehaviour
{
    // mga variables
    public int health = 100;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    private SpriteRenderer spriteRenderer;

    // Double jump
    public int extraJumpsValue = 1;
    private int extraJumps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        extraJumps = extraJumpsValue;
    }

    void Update()
    {
        // Player moves left/right
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            // Double jump
            else if (extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                extraJumps--;
            }
        }

        // Flips player when moving left/right
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

    // Lose health when damaged by enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            StartCoroutine(BlinkRed());

            if (health <= 0)
            {
                Die();
            }
        }
    }

    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Destroy(gameObject);
    }
}
