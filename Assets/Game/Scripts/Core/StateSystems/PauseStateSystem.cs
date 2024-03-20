using System.Collections.Generic;
using Entitas;

namespace Game
{
    public class PauseStateSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<EnemyEntity> _enemies;
        public PauseStateSystem(IContext<GameEntity> context) : base(context)
        {
            _enemies = Contexts.sharedInstance.enemy.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy, EnemyMatcher.Spawned).NoneOf(EnemyMatcher.Death));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Pause);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var enemy in _enemies)
            {
                enemy.navMeshAgent.value.isStopped = true;
            }
        }
    }
}