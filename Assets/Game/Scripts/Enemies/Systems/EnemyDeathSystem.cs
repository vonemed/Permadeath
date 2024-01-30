using System;
using System.Collections.Generic;
using Entitas;

namespace Enemies
{
    public class EnemyDeathSystem : ReactiveSystem<EnemyEntity>
    {
        public EnemyDeathSystem(IContext<EnemyEntity> context) : base(context)
        {
        }

        protected override ICollector<EnemyEntity> GetTrigger(IContext<EnemyEntity> context)
        {
            return context.CreateCollector(EnemyMatcher.Death);
        }

        protected override bool Filter(EnemyEntity entity)
        {
            return true;
        }

        protected override void Execute(List<EnemyEntity> entities)
        {
            foreach (var enemyEntity in entities)
            {
                //move to separate system?
                var player = Contexts.sharedInstance.player.baseEntity;
                var newXp = player.xp.value + enemyEntity.xpAward.value;
                
                //Level up
                if (newXp > 100)
                {
                    newXp -= 100;
                    player.ReplaceLevel(player.level.value++);
                }
                
                player.ReplaceXp(newXp);
                
                enemyEntity.RemoveNavMeshAgent();
                enemyEntity.transform.value.gameObject.SetActive(false); //todo: redo
            }
        }
    }
}