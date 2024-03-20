using ConfigScripts;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyView : MonoBehaviour, IEnemyResetListener
    {
        public EnemyEnums.EnemyType enemyType;
        
        public EnemyEntity linkedEntity;

        private void Awake()
        {
            var enemyStats = ConfigsManager.Instance.enemyConfig.GetEnemyPrefabData(enemyType).enemyStats;
            linkedEntity = Contexts.sharedInstance.enemy.CreateEntity();
            gameObject.Link(linkedEntity);

            linkedEntity.isEnemy = true;
            linkedEntity.AddTransform(transform);
            linkedEntity.AddNavMeshAgent(GetComponent<NavMeshAgent>());
            linkedEntity.requestPlayerTarget = true;
            
            linkedEntity.AddHealth(enemyStats.health);
            linkedEntity.AddDamage(enemyStats.attackDamage);
            linkedEntity.AddAttackRate(enemyStats.attackRate);
            linkedEntity.AddXpAward(enemyStats.xpReward);
            
            linkedEntity.AddEnemyResetListener(this);
        }

        private void OnDestroy()
        {
            gameObject.Unlink();
            linkedEntity.Destroy();
        }

        public void OnReset(EnemyEntity entity)
        {
            var enemyStats = ConfigsManager.Instance.enemyConfig.GetEnemyPrefabData(enemyType).enemyStats;
            
            // linkedEntity.ReplaceNavMeshAgent(GetComponent<NavMeshAgent>());
            linkedEntity.ReplaceHealth(enemyStats.health);
            linkedEntity.isSpawned = false;
            gameObject.SetActive(false);
        }
    }
}