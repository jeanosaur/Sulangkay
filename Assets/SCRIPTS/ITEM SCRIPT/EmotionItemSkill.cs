using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmotionSkill : MonoBehaviour
{
    private Player player;
    
    
    // For Double Jump
    public int extraJumpValue = 1;
    public int extraJump = 0;
   

    private void Start()
    {
        extraJump = 0;
        player = GetComponent<Player>(); //reference Player.cs
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.isSkillActive = true;
            player.isSkillUsed = false;
            Debug.Log("Skill Active and Not Used");
        }
    }
}
