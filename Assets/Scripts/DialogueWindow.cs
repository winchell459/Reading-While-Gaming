using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour
{
    DialogueTrigger controller;
    public Text ButtonText;
    public Text DialogueText;

    public void DisplayDialogue(Dialogue dialogue, DialogueTrigger controller)
    {
        this.controller = controller;
        ButtonText.text = dialogue.ButtonText;
        DialogueText.text = dialogue.DialogueText;
    }

    public void DialogueButton()
    {
        controller.DialogueButton();
    }
}