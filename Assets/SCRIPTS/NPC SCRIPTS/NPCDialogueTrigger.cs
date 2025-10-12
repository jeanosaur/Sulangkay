using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    public string[] dialogueLines; // multiple lines for each NPC

    private bool isPlayerInRange = false;
    private bool isDialogueActive = false;

    void Update()
    {
        // If player presses F near NPC
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!isDialogueActive)
            {
                // Start dialogue
                NPCDialogueManager.Instance.StartDialogue(dialogueLines);
                isDialogueActive = true;
            }
            else
            {
                // Advance or close dialogue
                NPCDialogueManager.Instance.DisplayNextLine();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Press [F] to talk");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            NPCDialogueManager.Instance.EndDialogue();
            isDialogueActive = false;
        }
    }
}
