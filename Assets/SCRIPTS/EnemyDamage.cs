using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public HealthSystem playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyBullet bullet = collision.gameObject.GetComponent<EnemyBullet>(); 
        if (bullet != null)
        {
            playerHealth.TakeDamage(bullet.damage);
            
            Destroy(collision.gameObject);
        }
    }
}
