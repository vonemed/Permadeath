using System.Collections.Generic;
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
            Debug.Log("Player is dead");
            Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Defeat);
        }
    }
}