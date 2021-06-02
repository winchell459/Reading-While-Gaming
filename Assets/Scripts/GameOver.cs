using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public TextMeshProUGUI timeText;
    public static float timeLeft = 30f;

    void Start()
    {
	timeLeft = 30f;
    }

    void Update()
    {
        timeLeft = timeLeft - Time.deltaTime; 
	timeText.text = "Time Left: " + timeLeft.ToString("0.00");

	if(timeLeft <= 0)
	{
	    Time.timeScale = 0f;
	    gameOver.SetActive(true);
	}
    }
}
