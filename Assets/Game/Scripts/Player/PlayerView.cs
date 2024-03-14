using System.Collections.Generic;
using Boosters;
using ConfigScripts;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public PlayerEntity linkedEntity;

        private PlayerConfig _playerConfig;
        private PlayerConfig.PlayerStats _playerStats;

        private Dictionary<BoosterEnums.PlayerStatType, float> statsHolder;

        public float GetStatByEnum(BoosterEnums.PlayerStatType stat) => statsHolder[stat];
        
        private void Start()
        {
            _playerConfig = ConfigsManager.Instance.playerConfig;
            
            linkedEntity = Contexts.sharedInstance.player.CreateEntity();
            gameObject.Link(linkedEntity);

            linkedEntity.isBase = true;
            linkedEntity.AddTransform(transform);
            linkedEntity.AddRigidbody(GetComponent<Rigidbody>());
            
            // linkedEntity.AddDamage(_playerConfig.playerStats.attackDamage);
            // linkedEntity.AddAttackRange(_playerConfig.playerStats.attackRange);
            // linkedEntity.AddAttackRate(_playerConfig.playerStats.attackRate);
            
            linkedEntity.AddPlayerBoosterInventory(new List<PlayerBooster>());

            var smth = Instantiate(_playerConfig);
            _playerStats = smth.playerStats;
            linkedEntity.AddPlayerStats(_playerStats);
            linkedEntity.AddHealth(_playerStats.GetStat(BoosterEnums.PlayerStatType.MaxHealth));
            linkedEntity.AddDefence(_playerStats.GetStat(BoosterEnums.PlayerStatType.Defence));
            linkedEntity.ReplacePlayerAttackSpeedCooldown(_playerStats.GetStat(BoosterEnums.PlayerStatType.AttackSpeed));
            
            linkedEntity.AddXp(0);
            linkedEntity.AddLevel(1);
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            linkedEntity.ReplaceMove(context.ReadValue<Vector3>());
        }
    }
}