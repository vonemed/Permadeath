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
            
            linkedEntity.AddPlayerBoosterInventory(new List<Booster>());
            linkedEntity.AddPlayerStats(_playerConfig.playerStats);
            linkedEntity.AddHealth(_playerConfig.playerStats.maxHealth);
            linkedEntity.AddDefence(_playerConfig.playerStats.defence);
            linkedEntity.ReplacePlayerAttackSpeedCooldown(_playerConfig.playerStats.attackRate);
            
            linkedEntity.AddXp(0);
            linkedEntity.AddLevel(1);
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            linkedEntity.ReplaceMove(context.ReadValue<Vector3>());
        }
    }
}