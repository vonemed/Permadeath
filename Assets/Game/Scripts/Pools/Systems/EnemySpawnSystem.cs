using System.Collections.Generic;
using ConfigScripts;
using Entitas;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pools
{
    public class EnemySpawnSystem  : ReactiveSystem<ObjectPoolerEntity>
    {
        public EnemySpawnSystem(IContext<ObjectPoolerEntity> context) : base(context)
        {
        }

        protected override ICollector<ObjectPoolerEntity> GetTrigger(IContext<ObjectPoolerEntity> context)
        {
            return context.CreateCollector(ObjectPoolerMatcher.CurrentWave);
        }

        protected override bool Filter(ObjectPoolerEntity entity)
        {
            return true;
        }

        protected override void Execute(List<ObjectPoolerEntity> entities)
        {
            foreach (var poolerEntity in entities)
            {
                if(poolerEntity.hasNextWaveTimer) poolerEntity.RemoveNextWaveTimer(); //if needed for the first spawn

                var currentWave = poolerEntity.enemyWaves.value[poolerEntity.currentWave.value];
                var spawnPos = poolerEntity.transform.value.position;
                var config = ConfigsManager.Instance.enemyConfig;

                for (int i = 0; i < currentWave.spawnAmount; i++)
                {
                    var randPos = new Vector3(spawnPos.x + Random.Range(-4f, 4f), spawnPos.y, spawnPos.z + Random.Range(-4f, 4f));
                    var gmbj = GameObject.Instantiate(config.GetEnemyPrefab(currentWave.enemyType), randPos, Quaternion.identity,poolerEntity.transform.value);
                }
                
                poolerEntity.ReplaceNextWaveTimer(currentWave.timeTillNextWave);
            }
        }
    }
}