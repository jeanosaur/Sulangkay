using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmotionItemSkill : MonoBehaviour
{
    private Player player;
    private PlayerInventory playerInventory;
    
    
    // For Double Jump ng joy item
    public int extraJumpValue = 1;
    public int extraJump = 0;
    public bool itemCollected = false;

    private void Start()
    {
        extraJump = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerInventory.inventory.Contains("Joy"))
        {
            playerInventory.inventory.Remove("Joy");
            player.isSkillActive = true;
            player.isSkillUsed = false;
            Debug.Log("Skill Active and Not Used");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player"))
        {
            Debug.Log("Collided with " + collide.name);
            itemCollected = true;
        }
    }

}
