using UnityEngine;

public class EmotionItemPickUp : MonoBehaviour
{
    public string emotionItemName = "Joy"; // 

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collide.GetComponent<PlayerInventory>();
            Player playerMovement = collide.GetComponent<Player>();

            if (playerInventory != null)
            {
                playerInventory.AddItem(emotionItemName);
                Debug.Log("Emotion item added");
            }

            if (playerMovement != null)
            {
            }
            Destroy(gameObject);
        }
    }
}
