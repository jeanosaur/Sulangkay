using UnityEngine;

public class Player : MonoBehaviour
{
    //callbacks(?) basta mga variables para sa baba haha
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    //double jump
    public int extraJumpsValue = 1;
    private int extraJumps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //add animator stuff here later

        extraJumps = extraJumpsValue;
    }

    void Update()
    {
        //player moves left/right
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        //double jump
            else if (extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                extraJumps--;
            }
        }

        //flips player when moving left/right
        if (moveInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (moveInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    //keeps player from eternally jumping into space
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

}
