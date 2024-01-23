using System;
using ConfigScripts;
using Entitas.Unity;
using UnityEditor;
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
            
            //todo: remove magical number, add to config
            linkedEntity.AddHealth(_playerConfig.health);
            linkedEntity.AddDamage(_playerConfig.attackDamage);
            linkedEntity.AddAttackRange(_playerConfig.attackRange);
            linkedEntity.AddAttackRate(_playerConfig.attackRate);
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            linkedEntity.ReplaceMove(context.ReadValue<Vector3>());
        }
    }
}