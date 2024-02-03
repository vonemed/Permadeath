using System.Collections.Generic;
using Entitas.Unity;
using Projectiles;
using UnityEngine;

namespace Pools
{
    public sealed class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private int spawnAmount;

        private ObjectPoolerEntity _linkedEntity;

        public static ProjectilePool Instance;

        public List<Projectile> spawnedObjects;

        private void Start()
        {
            spawnedObjects = new List<Projectile>();
            Instance = this;
            _linkedEntity = Contexts.sharedInstance.objectPooler.CreateEntity();
            gameObject.Link(_linkedEntity);

            for (int i = 0; i < spawnAmount; i++)
            {
                var randPos = new Vector3(transform.position.x + Random.Range(-4f, 4f), transform.position.y, transform.position.z + Random.Range(-4f, 4f));
                var gmbj = Instantiate(projectilePrefab, randPos, Quaternion.identity,transform);
                gmbj.SetActive(false);
                spawnedObjects.Add(gmbj.GetComponent<Projectile>());
            }
        }

        public Projectile RequestProjectile()
        {
            foreach (var spawnedObject in spawnedObjects)
            {
                if (!spawnedObject.gameObject.activeSelf) return spawnedObject;
            }

            return null;
        }
    }
}