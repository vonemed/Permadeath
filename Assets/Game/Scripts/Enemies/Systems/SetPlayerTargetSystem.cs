using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Enemies
{
    public class SetPlayerTargetSystem : ReactiveSystem<EnemyEntity>
    {
        public SetPlayerTargetSystem(IContext<EnemyEntity> context) : base(context)
        {
        }

        protected override ICollector<EnemyEntity> GetTrigger(IContext<EnemyEntity> context)
        {
            return context.CreateCollector(EnemyMatcher.PlayerTarget);
        }

        protected override bool Filter(EnemyEntity entity)
        {
            return true;
        }

        protected override void Execute(List<EnemyEntity> entities)
        {
            Debug.Log("requesting player target");
            foreach (var enemyEntity in entities)
            {
                enemyEntity.ReplaceEnemyTarget(Contexts.sharedInstance.player.baseEntity.transform.value);
                enemyEntity.requestPlayerTarget = false;
            }
        }
    }
}