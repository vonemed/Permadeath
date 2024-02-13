using System.Collections.Generic;
using Entitas;

namespace Game
{
    public class StateHandlerSystem : ReactiveSystem<GameEntity>
    {
        public StateHandlerSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CurrentState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var stateEntity in entities)
            {
                var currentState = stateEntity.currentState.value;

                switch (currentState)
                {
                    case (GameCore.GameState.Defeat):
                    {
                        Contexts.sharedInstance.game.CreateEntity().requestDefeat = true;
                        break;
                    }
                    
                    case (GameCore.GameState.Restart):
                    {
                        Contexts.sharedInstance.game.CreateEntity().requestRestart = true;
                        break;
                    }

                    case (GameCore.GameState.Pause):
                    {
                        Contexts.sharedInstance.game.CreateEntity().requestPause = true;
                        break;
                    }

                    case (GameCore.GameState.Play):
                    {
                        Contexts.sharedInstance.game.CreateEntity().requestPlay = true;
                        break;
                    }
                }
            }
        }
    }
}