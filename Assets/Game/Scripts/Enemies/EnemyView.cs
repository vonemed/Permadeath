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
            linkedEntity = Contexts.sharedInstance.enemy.CreateEntity();
            gameObject.Link(linkedEntity);

            linkedEntity.isEnemy = true;
            linkedEntity.AddTransform(transform);
            linkedEntity.AddNavMeshAgent(GetComponent<NavMeshAgent>());
            linkedEntity.requestPlayerTarget = true;
            
            linkedEntity.AddHealth(ConfigsManager.Instance.enemyConfig.health);
            linkedEntity.AddDamage(ConfigsManager.Instance.enemyConfig.attackDamage);
            linkedEntity.AddAttackRate(ConfigsManager.Instance.enemyConfig.attackRate);
            linkedEntity.AddXpAward(ConfigsManager.Instance.enemyConfig.GetEnemyPrefabData(enemyType).xpReward);
        }
    }
}