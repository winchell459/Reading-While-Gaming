using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject passagePage;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
	    {
	        if(pauseMenu.activeSelf)
	        {
		        Resume();
	        }

	        else
	        {
		        Pause();
	        }
	    }

        if (Input.GetKeyDown(KeyCode.P) && pauseMenu.activeSelf == (false))
        {
            if (passagePage.activeSelf)
            {
                HidePassage();
            }

            else
            {
                ShowPassage();
            }
        }
    }

    void Pause()
    {
	    pauseMenu.SetActive(true);
	    Time.timeScale = 0f;
    }

    public void Resume()
    {
	    Time.timeScale = 1f;
	    pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
	    Application.Quit();
    }

    void HidePassage()
    {
        passagePage.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ShowPassage()
    {
        Time.timeScale = 1f;
        passagePage.SetActive(true);
    }
}