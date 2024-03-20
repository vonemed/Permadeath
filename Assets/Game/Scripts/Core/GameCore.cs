
using System;
using Enemies;
using Loot;
using Player;
using Pools;
using UI;
using UI.GameUI;
using UnityEngine;

namespace Game
{
    public class GameCore : MonoBehaviour
    {
        public enum GameState
        {
            MainMenu,
            Play,
            Defeat,
            Victory,
            Pause,
            Restart
        }
        
        
        private GameSystems _gameSystems;
        private PlayerSystems _playerSystems;
        private PlayerFixedUpdateSystems _playerFixedUpdate;
        private EnemySystems _enemySystems;
        private LootSystems _lootSystems;
        private PoolSystems _poolSystems;

        public GameUISystems _gameUISystems;

        private void Awake()
        {
            _gameSystems = new GameSystems(Contexts.sharedInstance);
            _playerSystems = new PlayerSystems(Contexts.sharedInstance);
            _playerFixedUpdate = new PlayerFixedUpdateSystems(Contexts.sharedInstance);
            _enemySystems = new EnemySystems(Contexts.sharedInstance);
            _lootSystems = new LootSystems(Contexts.sharedInstance.loot);
            _poolSystems = new PoolSystems(Contexts.sharedInstance);

            _gameUISystems = new GameUISystems(Contexts.sharedInstance);
        }

        private void Start()
        {
            _gameSystems.Initialize();
            _playerSystems.Initialize();
            _enemySystems.Initialize();
            _lootSystems.Initialize();
            _poolSystems.Initialize();
            
            _gameUISystems.Initialize();
        }

        private void Update()
        {
            _gameSystems.Execute();

            if (Contexts.sharedInstance.game.stateHandlerEntity.hasCurrentState 
                && Contexts.sharedInstance.game.stateHandlerEntity.currentState.value == GameState.Play)
            {
                _playerSystems.Execute();
                _enemySystems.Execute();
                _poolSystems.Execute();
            }
            
            _gameUISystems.Execute();
            _lootSystems.Execute();

            _gameSystems.Cleanup();
            _playerSystems.Cleanup();
            _enemySystems.Cleanup();
            _lootSystems.Cleanup();
            _poolSystems.Cleanup();
            
            _gameUISystems.Cleanup();
        }

        private void FixedUpdate()
        {
            if (Contexts.sharedInstance.game.stateHandlerEntity.hasCurrentState
                && Contexts.sharedInstance.game.stateHandlerEntity.currentState.value == GameState.Play)
            {
                _playerFixedUpdate.Execute();
                _playerFixedUpdate.Cleanup();
            }
        }

        private void OnDestroy() //clear all systems
        {
            _playerSystems.DeactivateReactiveSystems();
            _playerFixedUpdate.DeactivateReactiveSystems();
            _enemySystems.DeactivateReactiveSystems();
            _poolSystems.DeactivateReactiveSystems();
            _lootSystems.DeactivateReactiveSystems();
            
            _gameUISystems.DeactivateReactiveSystems();
        }
    }
}