using System.Collections.Generic;
using System.Linq;
using Boosters;
using ConfigScripts;
using Entitas;
using Game;
using UnityEngine;

namespace Player.Systems
{
    public class PlayerDeathSystem : ReactiveSystem<PlayerEntity>
    {
        public PlayerDeathSystem(IContext<PlayerEntity> context) : base(context)
        {
        }

        protected override ICollector<PlayerEntity> GetTrigger(IContext<PlayerEntity> context)
        {
            return context.CreateCollector(PlayerMatcher.Death.Added());
        }

        protected override bool Filter(PlayerEntity entity)
        {
            return true;
        }

        protected override void Execute(List<PlayerEntity> entities)
        {
            var player = Contexts.sharedInstance.player.baseEntity;

            if (player.playerBoosterInventory.value.TrueForAll(x => x.cursed))
            {
                player.isPermaDeath = true;
                Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Defeat);
            }
            else
            {
                var playerBoosters = player.playerBoosterInventory.value.FindAll(x => !x.cursed);
                var randomPlayerBooster = playerBoosters[Random.Range(0, playerBoosters.Count)];

                player.ReplaceHealth(player.playerStats.value.GetStat(BoosterEnums.PlayerStatType.MaxHealth));
                Contexts.sharedInstance.uI.cursedPanelEntity.ReplaceCursedPanelBooster(randomPlayerBooster);
                Contexts.sharedInstance.uI.cursedPanelEntity.isShow = true;
                Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Pause);

                player.isDeath = false;
            }
        }
    }
}