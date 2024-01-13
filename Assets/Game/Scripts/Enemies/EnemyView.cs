using Entitas.Unity;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyView : MonoBehaviour
    {
        public EnemyEntity linkedEntity;

        private void Start()
        {
            linkedEntity = Contexts.sharedInstance.enemy.CreateEntity();
            gameObject.Link(linkedEntity);

            linkedEntity.isEnemy = true;
            linkedEntity.AddTransform(transform);
            linkedEntity.AddNavMeshAgent(GetComponent<NavMeshAgent>());
            linkedEntity.requestPlayerTarget = true;
            
            //todo: remove magical number, add to config
            linkedEntity.AddHealth(5);
            linkedEntity.AddDamage(1);
            linkedEntity.AddAttackRate(0.5f);
        }
    }
}