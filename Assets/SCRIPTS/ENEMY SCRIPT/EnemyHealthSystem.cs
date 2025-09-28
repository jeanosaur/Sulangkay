using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int EnemyHealth = 1;

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        if (EnemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
