using Entitas;
using UnityEngine;

namespace Pools
{
    public class EnemyPoolTimerSystem : IExecuteSystem
    {
        private IGroup<ObjectPoolerEntity> _enemyPools;

        public EnemyPoolTimerSystem(ObjectPoolerContext context)
        {
            _enemyPools = context.GetGroup(ObjectPoolerMatcher.AllOf(ObjectPoolerMatcher.EnemyPool, ObjectPoolerMatcher.NextWaveTimer));
        }
        
        public void Execute()
        {
            foreach (var enemyPool in _enemyPools)
            {
                enemyPool.nextWaveTimer.value -= Time.deltaTime;
                
                if (enemyPool.nextWaveTimer.value <= 0)
                {
                    var newWave = enemyPool.currentWave.value++;
                    if (newWave > enemyPool.enemyWaves.value.Count) newWave = 0;
                    
                    enemyPool.ReplaceCurrentWave(newWave);
                }
            }
        }
    }
}