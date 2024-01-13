using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

namespace Pools
{
    public class EnemyPooler : MonoBehaviour, ISpawnObjectsListener
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int spawnAmount;

        private ObjectPoolerEntity _linkedEntity;

        public static EnemyPooler Instance;

        public List<GameObject> spawnedObjects;

        private void Start()
        {
            spawnedObjects = new List<GameObject>();
            Instance = this;
            _linkedEntity = Contexts.sharedInstance.objectPooler.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isEnemyPool = true;
            _linkedEntity.AddSpawnObjectsListener(this);

            for (int i = 0; i < spawnAmount; i++)
            {
                var randPos = new Vector3(transform.position.x + Random.Range(-4f, 4f), transform.position.y, transform.position.z + Random.Range(-4f, 4f));
                var gmbj = Instantiate(enemyPrefab, randPos, Quaternion.identity,transform);
                spawnedObjects.Add(gmbj);
            }
        }

        public void OnSpawnObjects(ObjectPoolerEntity entity)
        {
            spawnedObjects.Clear();
            
            for (int i = 0; i < spawnAmount; i++)
            {
                var randPos = new Vector3(transform.position.x + Random.Range(-4f, 4f), transform.position.y, transform.position.z + Random.Range(-4f, 4f));
                var gmbj = Instantiate(enemyPrefab, randPos, Quaternion.identity,transform);
                spawnedObjects.Add(gmbj);
            }
        }
    }
}