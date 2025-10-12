using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmotionSkill : MonoBehaviour
{
    private Player player;
    private SpriteRenderer spriteRenderer;

    public Sprite defaultSprite; //default Sprite
    public Sprite joySprite;
    
    // For Double Jump
    public int extraJumpValue = 1;
    public int extraJump = 0;
   

    private void Start()
    {
        extraJump = 0;
        player = GetComponent<Player>(); //reference Player.cs
        spriteRenderer = GetComponent<SpriteRenderer>(); //Reference sa player Sprite Renderer

        if (spriteRenderer != null && defaultSprite != null)
        {
            spriteRenderer.sprite = defaultSprite; // Ensures correct starting sprite
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) //Toggle skill state
        {
            player.isSkillActive = !player.isSkillActive;

            if (player.isSkillActive)
            {
                player.isSkillUsed = false;
                Debug.Log("Double Jump Skill Activated!");

                if (spriteRenderer != null && joySprite != null) //change default to skill
                {
                    spriteRenderer.sprite = joySprite;
                }
            }
            else
            {
                player.isSkillUsed = true;
                Debug.Log("Double Jump Skill Deactivated!");
                
                if (spriteRenderer != null && defaultSprite != null)
                {
                    spriteRenderer.sprite = defaultSprite;
                }
            }
        }
    }
}
