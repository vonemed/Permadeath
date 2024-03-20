using Entitas;
using Game;
using GameApp;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovementSystem : IExecuteSystem
    {
        private IGroup<EnemyEntity> _enemies;

        public EnemyMovementSystem(EnemyContext context)
        {
            _enemies = context.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy, EnemyMatcher.Target, EnemyMatcher.Transform, EnemyMatcher.Spawned).NoneOf(EnemyMatcher.Death));
        }

        public void Execute()
        {
            foreach (var enemy in _enemies)
            {
                var source = new Vector2(enemy.transform.value.position.x, enemy.transform.value.position.z);
                var target = new Vector2(enemy.target.value.position.x, enemy.target.value.position.z);
                if (GameTools.IsInRange(source,
                        target, 1f))
                {
                    enemy.requestAttack = true;
                    return;
                }

                enemy.navMeshAgent.value.SetDestination(enemy.target.value.position);
            }
        }
    }
}