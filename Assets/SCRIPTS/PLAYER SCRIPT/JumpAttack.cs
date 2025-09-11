using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    public float bounceForce = 10f; // bounce
    public int jumpDamage = 1; // damage sa jump
    public string enemyTag = "Enemy"; // tag the enemy game object

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            if (rb.linearVelocity.y < 0)
            {
                EnemyHealthSystem enemyHealth = collision.gameObject.GetComponent<EnemyHealthSystem>(); // get the enemy health system
                if (enemyHealth != null)
                {
                 enemyHealth.TakeDamage(jumpDamage); //-1 damage ata
                 
                 rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
                }
            }
        }
    }
}