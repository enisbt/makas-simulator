using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadGame()
    {
        FindObjectOfType<GameSession>().SetAlive(true);
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadEndScreen()
    {
        SceneManager.LoadScene("End Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
