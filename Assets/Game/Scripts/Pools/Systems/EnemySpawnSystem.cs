using System.Collections.Generic;
using ConfigScripts;
using Entitas;
using Entitas.Unity;
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
                var spawnedObject = poolerEntity.spawnedObjects.value.Find(x => x.enemyType == currentWave.enemyType);
                var config = ConfigsManager.Instance.enemyConfig;

                for (int i = 0; i < currentWave.spawnAmount; i++)
                {
                    var randPos = new Vector3(poolerEntity.transform.value.position.x + Random.Range(-4f, 4f), poolerEntity.transform.value.position.y, poolerEntity.transform.value.position.z + Random.Range(-4f, 4f));
                    var obj = spawnedObject.GetInactiveObj();
                    
                    //if there is no inactive object in pool, then create one
                    if (obj == null)
                    {
                        obj = GameObject.Instantiate(config.GetEnemyPrefab(currentWave.enemyType), randPos, Quaternion.identity, poolerEntity.transform.value);
                        spawnedObject.objectPool.Add(obj);
                    }
                    else
                    {
                        obj.transform.position = randPos;
                    }
                    
                    obj.SetActive(true);
                    var objEntity = (EnemyEntity)obj.GetEntityLink().entity;
                    objEntity.isSpawned = true;
                    objEntity.isDeath = false;
                }
                
                poolerEntity.ReplaceNextWaveTimer(currentWave.timeTillNextWave);
            }
        }
    }
}