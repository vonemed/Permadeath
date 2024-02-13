using System.Collections.Generic;
using ConfigScripts;
using Entitas;

namespace Enemies
{
    public class EnemyAttackSystem : ReactiveSystem<EnemyEntity>
    {
        
        public EnemyAttackSystem(IContext<EnemyEntity> context) : base(context)
        {
        }

        protected override ICollector<EnemyEntity> GetTrigger(IContext<EnemyEntity> context)
        {
            return context.CreateCollector(EnemyMatcher.Attack);
        }

        protected override bool Filter(EnemyEntity entity)
        {
            return true;
        }

        protected override void Execute(List<EnemyEntity> entities)
        {
            foreach (var enemyEntity in entities)
            {
                //Manual component removal
                enemyEntity.requestAttack = false;
                
                var player = Contexts.sharedInstance.player.baseEntity;
                var currentHealth = (float)player.health.value;
                //If its not time to attack or player is dead, then skip
                if (enemyEntity.attackRate.value > 0
                    || player.isDeath) continue;

                player.ReplaceHealth( currentHealth - enemyEntity.damage.value);
                enemyEntity.ReplaceAttackRate(ConfigsManager.Instance.enemyConfig.attackRate);

                if (player.health.value <= 0) player.isDeath = true;
            }
        }
    }
}