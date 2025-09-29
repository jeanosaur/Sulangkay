using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int EnemyHealth = 3;

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
