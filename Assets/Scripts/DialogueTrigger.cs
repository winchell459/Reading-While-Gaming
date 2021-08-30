using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues;
    public DialogueWindow DialogueWindow;

    private int DialogueIndex = 0;
    public bool PausePlayer;
    public int DialogueID;

    private void DisplayDialogue()
    {
        DialogueWindow.gameObject.SetActive(true);
        FindObjectOfType<CharaScript>().PlayerMove = !PausePlayer;
        if (DialogueIndex < dialogues.Length)
        {
            DialogueWindow.gameObject.SetActive(true);

            DialogueWindow.DisplayDialogue(dialogues[DialogueIndex], this);
            DialogueIndex += 1;
        }
        else
        {
            DialogueWindow.gameObject.SetActive(false);
            FindObjectOfType<CharaScript>().PlayerMove = true;
            PlayerHandler.Singleton.SetDialogueCompleted(DialogueID);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && PlayerHandler.Singleton.IsDialogueCompleted(DialogueID))
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