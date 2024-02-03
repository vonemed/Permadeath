using Entitas;
using GameApp;
using UnityEngine;

namespace Loot
{
    public class LootFlyingSystem : IExecuteSystem
    {
        private IGroup<LootEntity> _loot;

        public LootFlyingSystem(IContext<LootEntity> context)
        {
            _loot = Contexts.sharedInstance.loot.GetGroup(LootMatcher.AllOf(LootMatcher.Loot, LootMatcher.FlyToTarget));
        }

        public void Execute()
        {
            foreach (var lootEntity in _loot)
            {
                var player = Contexts.sharedInstance.player.baseEntity;
                var moveDirection = player.transform.value.position - lootEntity.transform.value.position;
                var scaledMoveSpeed = 12f * Time.deltaTime;
                var newPos = moveDirection * scaledMoveSpeed;
                lootEntity.transform.value.Translate(new Vector3(newPos.x, 0, newPos.z));

                if (GameTools.IsInRange(lootEntity.transform.value.position, player.transform.value.position, 1f))
                {
                    Debug.Log("flying");
                    lootEntity.isPickedUp = true;
                    
                }
            }
        }
    }
}