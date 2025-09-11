using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] public int PlayerHealth; //tracks player's health
    [SerializeField] public int PlayerMaxHealth = 3; // full health

    private void Start()
    {
        PlayerHealth = PlayerMaxHealth; //sets current health to full
    }

    public void TakeDamage(int amount) // tracker of damage player takes
    {
         PlayerHealth -= amount;

            //if Player's HP reaches zero, the game object is destroyed
         if (PlayerHealth <= 0)
         {
             Destroy(gameObject);
         }
    }
}
    
