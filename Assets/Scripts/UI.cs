using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject Instructions1;
    public GameObject Instructions2;
    public GameObject Instructions3;
    public GameObject tilemap;
    public IEnumerator coroutine;

    void Start()
    {
	if(PlayerData.score == 0)
	{
	    coroutine = TurnOff(Instructions1);
	    StartCoroutine(coroutine);
	}
	else
	{
	    Instructions1.SetActive(false);
	}

	if(PlayerData.score == 1000)
	{
	    Instructions2.SetActive(true);
	    coroutine = TurnOff(Instructions2);
	    StartCoroutine(coroutine);
	    Debug.Log("coroutine ended");
	}
    }

    public void leave()
    {
	Instructions3.SetActive(true);
	coroutine = TurnOff(Instructions3);
	StartCoroutine(coroutine);
	tilemap.SetActive(true);
    }

    IEnumerator TurnOff(GameObject instr)
    {
	yield return new WaitForSecondsRealtime(3f);
	instr.SetActive(false);
	Time.timeScale = 1f;
    }
}