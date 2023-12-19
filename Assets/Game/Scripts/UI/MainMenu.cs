using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game..");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Assets/Game/Scenes/Game");
    }
}
