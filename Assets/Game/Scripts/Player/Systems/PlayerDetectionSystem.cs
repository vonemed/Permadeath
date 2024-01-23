using ConfigScripts;
using Entitas;
using GameApp;
using UnityEngine;

namespace Player.Systems
{
    public class PlayerDetectionSystem : IExecuteSystem
    {
        private IGroup<EnemyEntity> _enemies;

        private EnemyContext _enemyContext;
        public PlayerDetectionSystem(Contexts contexts)
        {
            
            _enemyContext = contexts.enemy;
        }
        
        public void Execute()
        {
            _enemies = _enemyContext.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy).NoneOf(EnemyMatcher.Death));
            
            var player = Contexts.sharedInstance.player.baseEntity;

            var source = new Vector2(player.transform.value.position.x, player.transform.value.position.z);
            
            foreach (var enemy in _enemies)
            {
                if(enemy.isDeath) continue;
                
                var target = new Vector2(enemy.transform.value.position.x, enemy.transform.value.position.x);

                if (GameTools.IsInRange(source, target, ConfigsManager.Instance.playerConfig.attackRange))
                {
                    player.ReplaceTarget(enemy.transform.value);
                    player.requestAttack = true;
                }
            }
        }
    }
}