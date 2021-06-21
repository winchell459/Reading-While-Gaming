using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject player;
    Vector2 scarPos;
    private int index;

    void Start()
    {
	index = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
	Debug.Log(SceneManager.GetActiveScene().buildIndex == 0);
	Debug.Log(SceneManager.GetActiveScene().buildIndex);

	if(SceneManager.GetActiveScene().buildIndex == 1)
	{
	    scarPos = player.transform.position;
	    scarPos.y = scarPos.y - 1.0f;
	    PlayerData.pos = scarPos;
	    SceneManager.LoadScene(index + 1);
	}
	else
	{
	    player.transform.position = PlayerData.pos;
	    PlayerData.score = player.GetComponent<CharaScript>().score;
	    Debug.Log(PlayerData.score);
	    Debug.Log("Door");
	    SceneManager.LoadScene(index - 1);
	}
    }
}