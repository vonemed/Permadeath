using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public class RestartStateSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<EnemyEntity> _enemies;
        
        public RestartStateSystem(IContext<GameEntity> context) : base(context)
        {
            _enemies = Contexts.sharedInstance.enemy.GetGroup(EnemyMatcher.Enemy);
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
            Contexts.sharedInstance.uI.defeatPanelEntity.isHide = true;
            
            //todo: magical number, put it config or smth
            Contexts.sharedInstance.player.baseEntity.transform.value.position = new Vector3(0, 1, 0); //Reset player pos
            Contexts.sharedInstance.player.baseEntity.isDeath = false;

            foreach (var enemy in _enemies)
            {
                enemy.navMeshAgent.value.ResetPath();
                enemy.navMeshAgent.value.gameObject.SetActive(false); //todo; trash, redo
            }

            Contexts.sharedInstance.objectPooler.enemyPoolEntity.isSpawnObjects = true;
            Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Play);
        }
    }
}