using System;
using System.Collections.Generic;
using ConfigScripts;
using Enemies;
using Entitas.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pools
{
    public class EnemyPooler : MonoBehaviour, ISpawnObjectsListener
    {
        [Serializable]
        public class EnemyData
        {
            [SerializeField] public EnemyEnums.EnemyType enemyType;
            [SerializeField] public int spawnAmount;
            [SerializeField] public float timeTillNextWave;
        }
        
        //Inspector
        public List<EnemyData> enemyWaves = new List<EnemyData>();

        //Internal
        private ObjectPoolerEntity _linkedEntity;

        public static EnemyPooler Instance;

        [HideInInspector] public List<GameObject> spawnedObjects;

        private void Start()
        {
            var config = ConfigsManager.Instance.enemyConfig;
            spawnedObjects = new List<GameObject>();
            Instance = this;
            _linkedEntity = Contexts.sharedInstance.objectPooler.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isEnemyPool = true;
            _linkedEntity.AddTransform(transform);
            _linkedEntity.AddEnemyWaves(enemyWaves);
            _linkedEntity.AddCurrentWave(0);

            _linkedEntity.AddSpawnObjectsListener(this);
            // for (int i = 0; i < enemyWaves[0].spawnAmount; i++)
            // {
            //     var randPos = new Vector3(transform.position.x + Random.Range(-4f, 4f), transform.position.y, transform.position.z + Random.Range(-4f, 4f));
            //     var gmbj = Instantiate(config.GetEnemyPrefab(enemyWaves[0].enemyType), randPos, Quaternion.identity,transform);
            //     spawnedObjects.Add(gmbj);
            // }
        }

        public void OnSpawnObjects(ObjectPoolerEntity entity)
        {
            //todo: redo later
            // spawnedObjects.Clear();
            //
            // for (int i = 0; i < spawnAmount; i++)
            // {
            //     var randPos = new Vector3(transform.position.x + Random.Range(-4f, 4f), transform.position.y, transform.position.z + Random.Range(-4f, 4f));
            //     var gmbj = Instantiate(enemyPrefab, randPos, Quaternion.identity,transform);
            //     spawnedObjects.Add(gmbj);
            // }
        }
    }
}