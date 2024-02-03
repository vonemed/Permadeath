using System.Collections.Generic;
using UnityEngine;

namespace Pools
{
    public sealed class LootPool : MonoBehaviour
    {
        [SerializeField] private GameObject xpPrefab;
        [SerializeField] private int spawnAmount;
        
        public static LootPool Instance;
        
        public List<Loot.Loot> spawnedObjects;

        private void Start()
        {
            Instance = this;

            for (int i = 0; i < spawnAmount; i++)
            {
                var randPos = new Vector3(transform.position.x + Random.Range(-4f, 4f), transform.position.y, transform.position.z + Random.Range(-4f, 4f));
                var gmbj = Instantiate(xpPrefab, randPos, Quaternion.identity,transform);
                gmbj.SetActive(false);
                spawnedObjects.Add(gmbj.GetComponent<Loot.Loot>());
            }
        }
        
        public Loot.Loot RequestLoot()
        {
            foreach (var spawnedObject in spawnedObjects)
            {
                if (!spawnedObject.gameObject.activeSelf) return spawnedObject;
            }

            return null;
        }
    }
}