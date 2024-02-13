using ConfigScripts;
using Entitas;
using GameApp;

namespace Player.Systems
{
    public class PlayerDetectionSystem : IExecuteSystem
    {
        private IGroup<EnemyEntity> _enemies;
        private IGroup<LootEntity> _loot;

        private EnemyContext _enemyContext;
        public PlayerDetectionSystem(Contexts contexts)
        {
            
            _enemyContext = contexts.enemy;
        }
        
        public void Execute()
        {
            _enemies = _enemyContext.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy).NoneOf(EnemyMatcher.Death));
            _loot = Contexts.sharedInstance.loot.GetGroup(LootMatcher.AllOf(LootMatcher.Loot, LootMatcher.Spawned).NoneOf(LootMatcher.PickedUp));
            
            var player = Contexts.sharedInstance.player.baseEntity;

            var source = player.transform.value.position;
            
            foreach (var enemy in _enemies)
            {
                if(enemy.isDeath) continue;
                
                var target = enemy.transform.value.position;

                if (GameTools.IsInRange(source, target, player.playerStats.value.attackRange))
                {
                    player.ReplaceTarget(enemy.transform.value);
                    player.requestAttack = true;
                }
            }

            foreach (var lootEntity in _loot)
            {
                var target = lootEntity.transform.value.position;

                if (GameTools.IsInRange(source, target, player.playerStats.value.pickUpRange))
                {
                    lootEntity.ReplaceTarget(player.transform.value);
                    lootEntity.isFlyToTarget = true;
                    // lootEntity.isPickedUp = true;
                    // player.ReplaceXp(player.xp.value + lootEntity.lootReward.value.xpReward);
                }
            }
        }
    }
}