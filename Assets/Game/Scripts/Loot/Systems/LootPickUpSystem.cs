using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Loot
{
    public class LootPickUpSystem : ReactiveSystem<LootEntity>
    {
        public LootPickUpSystem(IContext<LootEntity> context) : base(context)
        {
        }

        protected override ICollector<LootEntity> GetTrigger(IContext<LootEntity> context)
        {
            return context.CreateCollector(LootMatcher.PickedUp.Added());
        }

        protected override bool Filter(LootEntity entity)
        {
            return true;
        }

        protected override void Execute(List<LootEntity> entities)
        {
            foreach (var lootEntity in entities)
            {
                lootEntity.isFlyToTarget = false;
                lootEntity.isSpawned = false;
                lootEntity.isHide = true;
                Debug.Log("Xp Added");
                var player = Contexts.sharedInstance.player.baseEntity;
                player.ReplaceXp(player.xp.value + lootEntity.lootReward.value.xpReward);
            }
        }
    }
}