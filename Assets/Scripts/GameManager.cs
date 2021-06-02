using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Carnelian;
    public GameObject Instructions;
    public GameObject tm;

    void Start()
    {
        if(PlayerData.score == 1000)
	{
	    Carnelian.SetActive(true);
	    Instructions.SetActive(true);
	}

	else
	{
	    Carnelian.SetActive(false);
	    Instructions.SetActive(false);
	    tm.SetActive(false);
	}
    }
}