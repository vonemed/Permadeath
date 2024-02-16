using Entitas;
using UnityEngine;

namespace Boosters.Systems
{
    public class HealthRegenSystem : IExecuteSystem
    {
        public HealthRegenSystem(BoosterContext contexts)
        {
            
        }
        
        public void Execute()
        {
            var playerEntity = Contexts.sharedInstance.player.baseEntity;
            
            if(playerEntity.playerStats.value.healthRegen <= 0 || (decimal)playerEntity.health.value == (decimal)playerEntity.playerStats.value.maxHealth) return;

            var currentHealth = playerEntity.health.value;
            currentHealth += playerEntity.playerStats.value.healthRegen;
            currentHealth = Mathf.Clamp(currentHealth, 0, playerEntity.playerStats.value.maxHealth);
            playerEntity.ReplaceHealth(currentHealth);
        }
    }
}