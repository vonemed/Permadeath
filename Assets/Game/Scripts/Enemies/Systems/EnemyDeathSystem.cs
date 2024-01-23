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
                enemyEntity.RemoveNavMeshAgent();
                enemyEntity.transform.value.gameObject.SetActive(false); //todo: redo
            }
        }
    }
}