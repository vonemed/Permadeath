using ConfigScripts;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyView : MonoBehaviour
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
        }
    }
}