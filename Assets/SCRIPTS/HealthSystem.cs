using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}

    private void Awake()
    {
        currentHealth = startingHealth; 
    }

    private void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0f, startingHealth);

        if (currentHealth <= 0f)
        {
            // player hurt
        }

        else
        {
            //player dead 
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}
