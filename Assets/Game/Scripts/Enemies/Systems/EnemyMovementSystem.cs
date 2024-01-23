using Entitas;
using Game;
using GameApp;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovementSystem : IExecuteSystem
    {
        private IGroup<EnemyEntity> _enemies;

        public EnemyMovementSystem(EnemyContext context)
        {
            _enemies = context.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy, EnemyMatcher.Target, EnemyMatcher.Transform).NoneOf(EnemyMatcher.Death));
        }

        public void Execute()
        {
            if(Contexts.sharedInstance.game.stateHandlerEntity.currentState.value == GameCore.GameState.Defeat ||
               Contexts.sharedInstance.game.stateHandlerEntity.currentState.value == GameCore.GameState.Pause) return;
            
            foreach (var enemy in _enemies)
            {
                var source = new Vector2(enemy.transform.value.position.x, enemy.transform.value.position.z);
                var target = new Vector2(enemy.target.value.position.x, enemy.target.value.position.z);
                if (GameTools.IsInRange(source,
                        target, 1f))
                {
                    enemy.requestAttack = true;
                    return;
                }

                enemy.navMeshAgent.value.SetDestination(enemy.target.value.position);
            }
            // foreach (var enemy in _enemies)
            // {
            //     var source = new Vector2(enemy.transform.value.position.x, enemy.transform.value.position.z);
            //     var target = new Vector2(enemy.enemyTarget.value.position.x, enemy.enemyTarget.value.position.z);
            //     if (GameTools.IsInRange(source,
            //             target, 1f))
            //     {
            //         Debug.Log("ATTACKING PLAYER");
            //         return;
            //     }
            //     
            //     var scaledMoveSpeed = 1f * Time.deltaTime;
            //     var move = new Vector3(enemy.enemyTarget.value.position.x, 1, 
            //         enemy.enemyTarget.value.position.z);
            //     // var newPos = move * scaledMoveSpeed;
            //     // newPos.y = Mathf.Clamp(newPos.y, 0, 0);
            //
            //     var dir = enemy.enemyTarget.value.position - enemy.transform.value.position;
            //     var newPos = dir * scaledMoveSpeed;
            //
            //     enemy.transform.value.Translate(newPos);
            //     GizmoDrawer.Instance.DrawRay(enemy.transform.value.position, dir);
            //     
            //     Debug.Log($"Dir: {dir}");
            //     Debug.Log($"MoveSpeed: {scaledMoveSpeed}");
            //     Debug.Log($"Final move: {newPos}");
            // }
        }
    }
}