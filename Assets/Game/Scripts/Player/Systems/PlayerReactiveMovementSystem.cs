using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Player.Systems
{
    public class PlayerReactiveMovementSystem : ReactiveSystem<PlayerEntity>
    {
        public PlayerReactiveMovementSystem(IContext<PlayerEntity> context) : base(context)
        {
        }

        protected override ICollector<PlayerEntity> GetTrigger(IContext<PlayerEntity> context)
        {
            return context.CreateCollector(PlayerMatcher.Move);
        }

        protected override bool Filter(PlayerEntity entity)
        {
            return true;
        }

        protected override void Execute(List<PlayerEntity> entities)
        {
            foreach (var playerEntity in entities)
            {
                if (playerEntity.move.newPosition.sqrMagnitude == 0)
                    return;
                
                
                // var move = new Vector3(playerEntity.move.newPosition.x, 0, playerEntity.move.newPosition.z);
                // var scaledMoveSpeed = playerEntity.playerStats.value.moveSpeed * Time.deltaTime;
                // var newPos = move * scaledMoveSpeed;
                //
                // playerEntity.transform.value.GetComponent<Rigidbody>().MovePosition(newPos + move);
            }
        }
    }
}