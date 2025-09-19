using UnityEngine;
using System.Collections.Generic;

public class ItemDrop : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private bool isDead = false;
    
    public List<GameObject> inventory = new List<GameObject>();

    void Start()
    {
        currentHealth = maxHealth;

        foreach (GameObject item in inventory)
        {
            if (item != null)
            {
                item.SetActive(false);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        DropItemFromInventory();
        
        Destroy(gameObject);
    }

    private void DropItemFromInventory()
    {
        if (inventory.Count == 0)
        {
            return;
        }
        
        GameObject item = inventory[0];
        inventory.RemoveAt(0);

        if (item != null)
        {
            item.transform.position = transform.position;
            item.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
