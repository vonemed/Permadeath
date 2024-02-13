using Entitas;
using UnityEngine;

namespace Player.Systems
{
    public class PlayerAttackRateSystem : IExecuteSystem
    {
        public void Execute()
        {
            if (Contexts.sharedInstance.player.baseEntity.playerAttackSpeedCooldown.value > 0)
                Contexts.sharedInstance.player.baseEntity.playerAttackSpeedCooldown.value -= Time.deltaTime;
        }
    }
}