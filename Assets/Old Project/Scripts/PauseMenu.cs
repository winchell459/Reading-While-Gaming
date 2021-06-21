using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenu;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
	{
	    if(paused)
	    {
		Resume();
	    }

	    else
	    {
		Pause();
	    }
	}
    }

    void Pause()
    {
	pauseMenu.SetActive(true);
	Time.timeScale = 0f;
	paused = true;
    }

    public void Resume()
    {
	Time.timeScale = 1f;
	pauseMenu.SetActive(false);
	paused = false;
    }

    public void QuitGame()
    {
	Application.Quit();
    }
}