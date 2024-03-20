using System.Collections.Generic;
using Entitas;
using Game;
using UnityEngine;

namespace Player.Systems
{
    public class PlayerXpSystem : ReactiveSystem<PlayerEntity>
    {
        public PlayerXpSystem(IContext<PlayerEntity> context) : base(context)
        {
        }

        protected override ICollector<PlayerEntity> GetTrigger(IContext<PlayerEntity> context)
        {
            return context.CreateCollector(PlayerMatcher.Xp);
        }

        protected override bool Filter(PlayerEntity entity)
        {
            return true;
        }

        protected override void Execute(List<PlayerEntity> entities)
        {
            foreach (var playerEntity in entities)
            {
                var newXp = playerEntity.xp.value;
                
                //Level up
                if (newXp > 100)
                {
                    newXp -= 100;
                    var currentLevel = playerEntity.level.value;
                    playerEntity.ReplaceLevel(++currentLevel);
                    playerEntity.ReplaceXp(newXp);

                    Contexts.sharedInstance.gameUI.boosterChoosePanelEntity.isShow = true;
                    Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Pause);
                    return;
                }
                
                playerEntity.ReplaceXp(newXp);
            }
        }
    }
}