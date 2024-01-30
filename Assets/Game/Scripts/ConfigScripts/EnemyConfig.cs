using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace ConfigScripts
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("[Stats]")] 
        public float moveSpeed;
        public int health;
        public int attackDamage;
        public float attackRange;
        public float attackRate;

        [Header("[Prefabs]")] 
        public List<EnemyPrefabData> enemyPrefabs = new List<EnemyPrefabData>();

        [Serializable]
        public class EnemyPrefabData
        {
            public EnemyEnums.EnemyType enemyType;
            public GameObject enemyPrefab;

            public int xpReward;
        }

        public GameObject GetEnemyPrefab(EnemyEnums.EnemyType enemyType) => enemyPrefabs.Find(x => x.enemyType == enemyType).enemyPrefab;
        public EnemyPrefabData GetEnemyPrefabData(EnemyEnums.EnemyType enemyType) => enemyPrefabs.Find(x => x.enemyType == enemyType);

    }
}