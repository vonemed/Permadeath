using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public class PlayStateSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<EnemyEntity> _enemies;

        public PlayStateSystem(IContext<GameEntity> context) : base(context)
        {
            _enemies = Contexts.sharedInstance.enemy.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy).NoneOf(EnemyMatcher.Death));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Play);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Debug.Log("we playin");
            foreach (var enemy in _enemies)
            {
                enemy.navMeshAgent.value.isStopped = false;
                enemy.requestPlayerTarget = true;
            }
        }
    }
}