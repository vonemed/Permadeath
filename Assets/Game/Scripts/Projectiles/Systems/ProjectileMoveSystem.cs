using System.Linq;
using ConfigScripts;
using Entitas;
using GameApp;
using UnityEngine;

namespace Projectiles
{
    public class ProjectileMoveSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _projectiles;
        private IGroup<EnemyEntity> _enemies;

        public ProjectileMoveSystem(GameContext context)
        {
            _projectiles = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Projectile, GameMatcher.Target, GameMatcher.MoveDirection,
                GameMatcher.MovementSpeed));
                
            _enemies = Contexts.sharedInstance.enemy.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy));

        }
        
        public void Execute()
        {
            foreach (var projectile in _projectiles)
            {
                Debug.DrawRay(Contexts.sharedInstance.player.baseEntity.transform.value.position, 
                    projectile.moveDirection.value * 15f);
                
                Debug.DrawRay(projectile.transform.value.position, 
                    projectile.moveDirection.value * 15f, Color.green);
                

                // var testPos = new Vector3(projectile.moveDirection.value.x, 0, projectile.moveDirection.value.z);
                // projectile.transform.value.LookAt(projectile.target.value);
                projectile.transform.value.Translate(projectile.moveDirection.value);

                if (GameTools.IsInRange(projectile.transform.value.position, projectile.target.value.position, 1f))
                {
                    projectile.isOff = true;
                    var enemy = _enemies.GetEntities().ToList().Find(x => x.transform.value == projectile.target.value);
                    enemy.ReplaceHealth(enemy.health.value -= projectile.damage.value);

                    GameObject.Instantiate(ConfigsManager.Instance.particlesConfig.defaultImpact, projectile.target.value.position + Vector3.up, Quaternion.identity);
                    

                    if (enemy.health.value <= 0) enemy.isDeath = true;
                }
            }
        }
    }
}