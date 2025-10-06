using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HealthSystem : MonoBehaviour
{
    public int PlayerHealth; //tracks player's health
    public int PlayerMaxHealth = 5; // full health
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        PlayerHealth = PlayerMaxHealth; //sets current health to full
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage) // tracker of damage player takes
    {
         PlayerHealth -= damage;
         StartCoroutine(BlinkRed());
        
            //if Player's HP reaches zero, the game object is destroyed
         if (PlayerHealth <= 0)
         {
             Die();
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
    public IEnumerator BlinkRed() //player blinks red when taking damage
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    }
}
    
