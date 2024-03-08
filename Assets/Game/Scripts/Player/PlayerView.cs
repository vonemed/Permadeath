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
            
            linkedEntity.AddPlayerBoosterInventory(new List<int>());

            _playerStats = _playerConfig.playerStats;
            linkedEntity.AddPlayerStats(_playerStats);
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

        private void SetupStats()
        {
            statsHolder = new Dictionary<BoosterEnums.PlayerStatType, float>();
            
            statsHolder.Add(BoosterEnums.PlayerStatType.MoveSpeed, _playerConfig.playerStats.moveSpeed);
            statsHolder.Add(BoosterEnums.PlayerStatType.MaxHealth, _playerConfig.playerStats.maxHealth);
            statsHolder.Add(BoosterEnums.PlayerStatType.AttackDamage, _playerConfig.playerStats.attackDamage);
            statsHolder.Add(BoosterEnums.PlayerStatType.AttackRange, _playerConfig.playerStats.attackRange);
            statsHolder.Add(BoosterEnums.PlayerStatType.AttackSpeed, _playerConfig.playerStats.attackRate);
            statsHolder.Add(BoosterEnums.PlayerStatType.CritChance, _playerConfig.playerStats.critChance);
            statsHolder.Add(BoosterEnums.PlayerStatType.PureDamageChance, _playerConfig.playerStats.pureDamageChance);
            statsHolder.Add(BoosterEnums.PlayerStatType.HealthRegen, _playerConfig.playerStats.healthRegen);
            statsHolder.Add(BoosterEnums.PlayerStatType.DodgeChance, _playerConfig.playerStats.dodgeChance);
            statsHolder.Add(BoosterEnums.PlayerStatType.Defence, _playerConfig.playerStats.defence);
            statsHolder.Add(BoosterEnums.PlayerStatType.PickupRange, _playerConfig.playerStats.pickUpRange);
            statsHolder.Add(BoosterEnums.PlayerStatType.ProjectileAmount, _playerConfig.playerStats.projectileAmount);
            statsHolder.Add(BoosterEnums.PlayerStatType.AbilityCooldown, _playerConfig.playerStats.abilityCooldown);
        }
    }
}