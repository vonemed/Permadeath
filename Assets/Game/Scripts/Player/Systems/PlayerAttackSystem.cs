using System.Collections.Generic;
using ConfigScripts;
using Entitas;
using Pools;
using UnityEngine;

namespace Player.Systems
{
    public class PlayerAttackSystem : ReactiveSystem<PlayerEntity>
    {
        public PlayerAttackSystem(IContext<PlayerEntity> context) : base(context)
        {
        }

        protected override ICollector<PlayerEntity> GetTrigger(IContext<PlayerEntity> context)
        {
            return context.CreateCollector(PlayerMatcher.Attack);
        }

        protected override bool Filter(PlayerEntity entity)
        {
            return true;
        }

        protected override void Execute(List<PlayerEntity> entities)
        {
            var player = Contexts.sharedInstance.player.baseEntity;

            //Manual component removal
            player.requestAttack = false;

            //If its not time to attack or player is dead, then skip
            if (player.playerAttackSpeedCooldown.value > 0
                || player.isDeath) return;
            
            
            var projectile = ProjectilePool.Instance.RequestProjectile();
            projectile.gameObject.SetActive(true);
            
            var projectileEntity = projectile.linkedEntity;
            var projectileDirection = player.target.value.position - player.transform.value.position;
            
            var scaledMoveSpeed = 5f * Time.deltaTime;
            var newPos = projectileDirection * scaledMoveSpeed;
            projectileEntity.transform.value.position = player.transform.value.position;
            projectileEntity.transform.value.Rotate(projectileDirection * 5f * Time.deltaTime);
            projectileEntity.ReplaceDamage(player.playerStats.value.attackDamage);
            projectileEntity.ReplaceTarget(player.target.value);
            projectileEntity.ReplaceMoveDirection(new Vector3(newPos.x, 0, newPos.z));
            projectileEntity.ReplaceMovementSpeed(5f);

            Debug.Log("Attack");
            // player.ReplaceAttackRate(player.playerStats.value.attackRate);
            player.ReplacePlayerAttackSpeedCooldown(player.playerStats.value.attackRate);
        }
    }
}