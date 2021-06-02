using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPC : MonoBehaviour
{
    public NPCConversation conversation;

    void Start()
    {
        if(PlayerData.score > 800)
	{
	    gameObject.SetActive(true);
	}
    }

    private void OnMouseOver()
    {
	if(Input.GetMouseButtonDown(0))
	{
	    ConversationManager.Instance.StartConversation(conversation);
	}
    }
}
