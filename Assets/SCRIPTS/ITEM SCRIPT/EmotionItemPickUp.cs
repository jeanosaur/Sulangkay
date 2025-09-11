using UnityEngine;

public class EmotionItemPickUp : MonoBehaviour
{
    public string emotionItemName = "Joy";

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collide.GetComponent<PlayerInventory>();
            PlayerMovement playerMovement = collide.GetComponent<PlayerMovement>();

            if (playerInventory != null)
            {
                playerInventory.AddItem(emotionItemName);
            }

            if (playerMovement != null)
            {
                playerMovement.doubleJumpEnabled = true;
            }
            Destroy(gameObject);
        }
    }
}
