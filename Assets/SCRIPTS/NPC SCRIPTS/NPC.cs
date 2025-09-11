using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NPCNameText;
    public string[] dialogue;
    public int index;
    
    public GameObject continueButton;
    public float speed;
    public bool playerIsClose;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose) //Trigger Dialogue when pressed F
        {
            if (DialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                DialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (DialogueText.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void zeroText() //reset
    {
        DialogueText.text = "";
        index = 0;
        DialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }

    public void Next()
    {
        continueButton.SetActive(false);
        
        if (index < dialogue.Length - 1)
        {
            index++;
            DialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // para madetect ang player ng NPC object
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}