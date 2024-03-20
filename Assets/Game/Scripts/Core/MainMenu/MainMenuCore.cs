using DefaultNamespace;
using UI;
using UnityEngine;

public class MainMenuCore : MonoBehaviour
{
    private MainMenuSystems _mainMenuSystems;
    private UISystems _uiSystems;

    private void Awake()
    {
        _mainMenuSystems = new MainMenuSystems(Contexts.sharedInstance);
        _uiSystems = new UISystems(Contexts.sharedInstance);

    }

    private void Start()
    {
        _mainMenuSystems.Initialize();
        _uiSystems.Initialize();

    }

    private void Update()
    {
        _mainMenuSystems.Execute();
        _uiSystems.Execute();
        _uiSystems.Cleanup();

    }
    //State
    //MainMenuUI
}