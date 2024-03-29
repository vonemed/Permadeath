using System;
using System.Collections.Generic;
using Entitas;
using Pools;
using UnityEngine;

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
                var lootAward = LootPool.Instance.RequestLoot();
                lootAward.linkedEntity.ReplaceLootReward(new Loot.Loot.Reward() { xpReward =  enemyEntity.xpAward.value});
                lootAward.transform.position = enemyEntity.transform.value.position;
                lootAward.linkedEntity.isShow = true;
                lootAward.linkedEntity.isPickedUp = false;
                lootAward.linkedEntity.isSpawned = true;
                
                enemyEntity.isReset = true;
            }
        }
    }
}