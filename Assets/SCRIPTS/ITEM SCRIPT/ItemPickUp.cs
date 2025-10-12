using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public string collectibleItemName = "Rice Stalk";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerQuestItemInventory inventory = other.GetComponent<PlayerQuestItemInventory>();

            if (inventory != null)
            {
                inventory.AddItem(collectibleItemName);
            }
            Destroy(gameObject);
        }
    }
}