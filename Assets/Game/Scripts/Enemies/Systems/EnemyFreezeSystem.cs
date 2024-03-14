using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitas;
using UnityEngine;

namespace Enemies
{
    public class EnemyFreezeSystem : ReactiveSystem<EnemyEntity>
    {
        private IGroup<EnemyEntity> enemies;
        
        public EnemyFreezeSystem(IContext<EnemyEntity> context) : base(context)
        {
            enemies = context.GetGroup(EnemyMatcher.AllOf(EnemyMatcher.Enemy).NoneOf(EnemyMatcher.Death));
        }

        protected override ICollector<EnemyEntity> GetTrigger(IContext<EnemyEntity> context)
        {
            return context.CreateCollector(EnemyMatcher.FreezeAllEnemies);
        }

        protected override bool Filter(EnemyEntity entity)
        {
            return true;
        }

        protected override void Execute(List<EnemyEntity> entities)
        {
            Debug.Log("Enemies are frozen");
            foreach (var enemy in enemies)
            {
                enemy.isFreeze = true;
            }

            var timer = entities.FirstOrDefault()!.freezeAllEnemies.timeToUnfreeze;

            if (timer > 0)
            {
                // AnimTimer(timer);
            }
        }
        
        private async void AnimTimer(float timeToFinish)
        {
            var seconds = 0f;
            while (seconds < timeToFinish)
            {
                seconds += Time.deltaTime;
                await Task.Yield();
            }

            foreach (var enemy in enemies)
            {
                enemy.isFreeze = false;
            }
        }
    }
}