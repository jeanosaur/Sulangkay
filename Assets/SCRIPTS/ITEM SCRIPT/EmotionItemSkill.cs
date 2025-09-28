using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmotionItemSkill : MonoBehaviour
{
    public EmotionItemPickUp emotionItemPickUp;
    
    // For Double Jump ng joy item
    public int extraJumpValue = 1;
    public int extraJump = 0;
    private bool itemCollected = false;

    private void Start()
    {
        extraJump = 0;
    }

    private void Update()
    {
        if (itemCollected && Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateExtraJump();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemCollected = true;
        }
    }

    private void ActivateExtraJump()
    {
        extraJump = extraJumpValue;
    }
}
