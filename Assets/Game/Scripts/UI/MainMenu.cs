using UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public MainMenuPanel mainMenuPanel;

    private void Awake()
    {
        mainMenuPanel.Ctor();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
