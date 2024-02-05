using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    void Awake()
    {
        // Ensure the game over screen is not visible initially
        gameObject.SetActive(false);
    }

    public void Setup()
    {
        Time.timeScale = 0; // Pause the game
        gameObject.SetActive(true); // Activate the Game Over screen
    }

    public void RestartButton()
    {
        Time.timeScale = 1; // Resume normal time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1; // Resume normal time scale before loading the main menu
        SceneManager.LoadScene("Game/Scenes/MainMenu"); // Load the main menu scene; replace "MainMenu" with your scene name
    }
}