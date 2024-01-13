using System;
using UnityEngine;

namespace Game
{
    public class GameCore : MonoBehaviour
    {
        public enum GameState
        {
            Play,
            Defeat,
            Victory,
            Pause,
            Restart
        }
        
        
        private GameSystems _gameSystems;

        private void Awake()
        {
            _gameSystems = new GameSystems(Contexts.sharedInstance);
        }

        private void Start()
        {
            _gameSystems.Initialize();
        }

        private void Update()
        {
            _gameSystems.Execute();
            _gameSystems.Cleanup();
        }
    }
}