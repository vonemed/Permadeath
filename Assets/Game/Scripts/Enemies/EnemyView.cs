using ConfigScripts;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyView : MonoBehaviour
    {
        public EnemyEntity linkedEntity;

        private void Awake()
        {
            linkedEntity = Contexts.sharedInstance.enemy.CreateEntity();
            gameObject.Link(linkedEntity);

            linkedEntity.isEnemy = true;
            linkedEntity.AddTransform(transform);
            linkedEntity.AddNavMeshAgent(GetComponent<NavMeshAgent>());
            linkedEntity.requestPlayerTarget = true;
            
            //todo: remove magical number, add to config
            linkedEntity.AddHealth(ConfigsManager.Instance.enemyConfig.health);
            linkedEntity.AddDamage(ConfigsManager.Instance.enemyConfig.attackDamage);
            linkedEntity.AddAttackRate(ConfigsManager.Instance.enemyConfig.attackRate);
        }
    }
}