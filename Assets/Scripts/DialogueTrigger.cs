using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues;
    public DialogueWindow DialogueWindow;

    private int DialogueIndex = 0;
    public bool PausePlayer;

    private void DisplayDialogue()
    {
        FindObjectOfType<CharaScript>().PlayerMove = !PausePlayer;
        if(DialogueIndex < dialogues.Length)
        {
            DialogueWindow.gameObject.SetActive(true);

            DialogueWindow.DisplayDialogue(dialogues[DialogueIndex], this);
            DialogueIndex += 1;
        }
        else
        {
            DialogueWindow.gameObject.SetActive(false);
            FindObjectOfType<CharaScript>().PlayerMove = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;
            DisplayDialogue();
        }
    }

    public void DialogueButton()
    {
        DisplayDialogue();
    }
}