using System.Collections.Generic;
using Entitas;

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
                    playerEntity.ReplaceLevel(playerEntity.level.value++);
                }
                
                playerEntity.ReplaceXp(newXp);
            }

        }
    }
}