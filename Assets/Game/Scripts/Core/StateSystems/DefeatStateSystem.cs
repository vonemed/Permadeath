using System.Collections.Generic;
using Entitas;

namespace Game
{
    public class DefeatStateSystem : ReactiveSystem<GameEntity>
    {
        public DefeatStateSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Defeat);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Contexts.sharedInstance.uI.defeatPanelEntity.isShow = true;
        }
    }
}