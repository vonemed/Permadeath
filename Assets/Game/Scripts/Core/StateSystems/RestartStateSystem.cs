using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public class RestartStateSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<EnemyEntity> _enemies;
        private IGroup<ObjectPoolerEntity> _enemyPools;

        public RestartStateSystem(IContext<GameEntity> context) : base(context)
        {
            _enemies = Contexts.sharedInstance.enemy.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy, EnemyMatcher.Spawned));
            _enemyPools = Contexts.sharedInstance.objectPooler.GetGroup(ObjectPoolerMatcher.AllOf(ObjectPoolerMatcher.EnemyPool));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Restart);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var player = Contexts.sharedInstance.player.baseEntity;
            Contexts.sharedInstance.uI.defeatPanelEntity.isHide = true;
            
            //todo: magical number, put it config or smth
            player.transform.value.position = new Vector3(0, 1, 0); //Reset player pos
            player.isDeath = false;
            player.isPermaDeath = false;
            player.isReset = true;

            foreach (var enemy in _enemies)
            {
                enemy.navMeshAgent.value.ResetPath();
                enemy.isDeath = false;
                enemy.isReset = true;
            }

            //todo: this is temporary trash
            foreach (var enemyPool in _enemyPools)
            {
                enemyPool.isReset = true;
            }
            // Contexts.sharedInstance.objectPooler.enemyPoolEntity.isSpawnObjects = true; //this is the way
            Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Play);
            Contexts.sharedInstance.uI.pausePanelEntity.isHide = true;
            Contexts.sharedInstance.uI.defeatPanelEntity.isHide = true;
        }
    }
}