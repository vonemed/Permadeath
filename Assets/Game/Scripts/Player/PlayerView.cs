using System.Collections.Generic;
using Boosters;
using ConfigScripts;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerView : MonoBehaviour, IPlayerResetListener
    {
        public PlayerEntity linkedEntity;

        private PlayerConfig _playerConfig;
        private PlayerConfig.PlayerStats _playerStats;
        
        private void Start()
        {
            _playerConfig = ConfigsManager.Instance.playerConfig;
            
            linkedEntity = Contexts.sharedInstance.player.CreateEntity();
            gameObject.Link(linkedEntity);

            linkedEntity.isBase = true;
            linkedEntity.AddTransform(transform);
            linkedEntity.AddRigidbody(GetComponent<Rigidbody>());
            
            linkedEntity.AddPlayerResetListener(this);
            
            InitialSetup();
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            linkedEntity.ReplaceMove(context.ReadValue<Vector3>());
        }

        private void OnDestroy()
        {
            gameObject.Unlink();
            linkedEntity.Destroy();
        }

        private void InitialSetup()
        {
            var smth = Instantiate(_playerConfig);
            _playerStats = smth.playerStats;
            
            linkedEntity.ReplacePlayerStats(_playerStats);
            linkedEntity.ReplaceHealth(_playerStats.GetStat(BoosterEnums.PlayerStatType.MaxHealth));
            linkedEntity.ReplaceDefence(_playerStats.GetStat(BoosterEnums.PlayerStatType.Defence));
            linkedEntity.ReplacePlayerAttackSpeedCooldown(_playerStats.GetStat(BoosterEnums.PlayerStatType.AttackSpeed));
            linkedEntity.ReplacePlayerBoosterInventory(new List<PlayerBooster>());
            
            linkedEntity.ReplaceXp(0);
            linkedEntity.ReplaceLevel(1);
        }

        public void OnReset(PlayerEntity entity)
        {
            InitialSetup();
        }
    }
}