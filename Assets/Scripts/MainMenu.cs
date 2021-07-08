using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Overworld = "Overworld";

    public void PlayGame()
    {
        SceneManager.LoadScene(Overworld);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
