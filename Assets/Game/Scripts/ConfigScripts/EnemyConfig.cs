using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace ConfigScripts
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("[Prefabs]")] 
        public List<EnemyPrefabData> enemyPrefabs = new List<EnemyPrefabData>();

        [Serializable]
        public class EnemyPrefabData
        {
            public GameObject enemyPrefab;
            public EnemyEnums.EnemyType enemyType;
            public EnemyStats enemyStats;
        }

        [Serializable]
        public class EnemyStats
        {
            public float moveSpeed;
            public uint health;
            public uint attackDamage;
            public float attackRange;
            public float attackRate;
            public float defence;
            public float dodgeChance;
            public float critChance;
            
            public int xpReward;
        }

        public GameObject GetEnemyPrefab(EnemyEnums.EnemyType enemyType) => enemyPrefabs.Find(x => x.enemyType == enemyType).enemyPrefab;
        public EnemyPrefabData GetEnemyPrefabData(EnemyEnums.EnemyType enemyType) => enemyPrefabs.Find(x => x.enemyType == enemyType);

    }
}