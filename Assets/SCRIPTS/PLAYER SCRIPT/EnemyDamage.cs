using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public HealthSystem playerHealth; //calls the health system

    // kapag natamaan ang player ng collision
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        EnemyBullet bullet = collision.gameObject.GetComponent<EnemyBullet>(); //calls enemy bullet prefab
        if (bullet != null)
        {
            playerHealth.TakeDamage(bullet.damage);
            Destroy(collision.gameObject);
        }
    }
}
