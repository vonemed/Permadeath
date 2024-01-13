using Entitas;
using UnityEngine;

namespace Enemies
{
    public class EnemyAttackRateSystem : IExecuteSystem
    {
        private IGroup<EnemyEntity> _enemies;

        public EnemyAttackRateSystem(EnemyContext context)
        {
            _enemies = context.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy, EnemyMatcher.AttackRate));
        }

        public void Execute()
        {
            foreach (var enemy in _enemies)
            {
                if (enemy.attackRate.value > 0)
                    enemy.attackRate.value -= Time.deltaTime;
            }
        }
    }
}