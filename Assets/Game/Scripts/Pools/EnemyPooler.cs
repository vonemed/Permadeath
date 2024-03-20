using System;
using System.Collections.Generic;
using ConfigScripts;
using Enemies;
using Entitas.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pools
{
    public class EnemyPooler : MonoBehaviour, IObjectPoolerResetListener
    {
        [Serializable]
        public class EnemyData
        {
            [SerializeField] public EnemyEnums.EnemyType enemyType;
            [SerializeField] public int spawnAmount;
            [SerializeField] public float timeTillNextWave;
        }

        [Serializable]
        public class SpawnedObject
        {
            public EnemyEnums.EnemyType enemyType;
            public List<GameObject> objectPool = new List<GameObject>();

            public GameObject GetInactiveObj()
            {
                foreach (var o in objectPool)
                {
                    if (!o.activeSelf) return o;
                }

                return null;
            }
        }
        
        //Inspector
        public List<EnemyData> enemyWaves = new List<EnemyData>();

        //Internal
        private ObjectPoolerEntity _linkedEntity;

        public static EnemyPooler Instance;

        [HideInInspector] public List<SpawnedObject> spawnedObjects;

        private void Start()
        {
            spawnedObjects = new List<SpawnedObject>();
            Instance = this;
            _linkedEntity = Contexts.sharedInstance.objectPooler.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isEnemyPool = true;
            _linkedEntity.AddTransform(transform);
            _linkedEntity.AddEnemyWaves(enemyWaves);

            InitialState();

            _linkedEntity.AddObjectPoolerResetListener(this);
        }

        private void OnDestroy()
        {
            gameObject.Unlink();
            _linkedEntity.Destroy();
        }

        private void InitialState()
        {
            spawnedObjects.Clear();
            
            var config = ConfigsManager.Instance.enemyConfig;
            var spawnedList = new List<GameObject>();

            foreach (var enemyWave in enemyWaves)
            {
                spawnedList.Clear();
                for (int i = 0; i < enemyWave.spawnAmount; i++)
                {
                    var randPos = new Vector3(transform.position.x + Random.Range(-4f, 4f), transform.position.y, transform.position.z + Random.Range(-4f, 4f));
                    var gmbj = Instantiate(config.GetEnemyPrefab(enemyWave.enemyType), randPos, Quaternion.identity, transform);
                    gmbj.SetActive(false);
                    spawnedList.Add(gmbj);
                }

                var check = spawnedObjects.Find(x => x.enemyType == enemyWave.enemyType);

                if (check != null)
                {
                    var indx = spawnedObjects.IndexOf(check);
                    spawnedObjects[indx].objectPool.AddRange(spawnedList);
                }
                else
                {
                    spawnedObjects.Add(new SpawnedObject()
                    {
                        enemyType = enemyWave.enemyType,
                        objectPool = new List<GameObject>()
                    });
                    
                    //trash todo: redo
                    spawnedObjects.Find(x => x.enemyType == enemyWave.enemyType).objectPool.AddRange(spawnedList);
                }
            }
            
            _linkedEntity.ReplaceSpawnedObjects(spawnedObjects);
            _linkedEntity.ReplaceCurrentWave(0);
            
            if(_linkedEntity.hasNextWaveTimer) _linkedEntity.RemoveNextWaveTimer();
        }

        public void OnReset(ObjectPoolerEntity entity)
        {
            InitialState();
        }
    }
}