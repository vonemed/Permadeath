using Entitas;
using UnityEngine;

namespace Player.Systems
{
    public class PlayerMovementSystem : IExecuteSystem
    {
        readonly IGroup<PlayerEntity> _moves;
        public PlayerMovementSystem(Contexts contexts)
        {
            _moves = contexts.player.GetGroup(PlayerMatcher.Move);
        }

        public void Execute()
        {
            foreach (var playerEntity in _moves)
            {
                if (playerEntity.move.newPosition.sqrMagnitude < 0.01)
                    return;

                var scaledMoveSpeed = 20 * Time.deltaTime;
                // For simplicity's sake, we just keep movement in a single plane here. Rotate
                // direction according to world Y rotation of player.
                var move = new Vector3(playerEntity.move.newPosition.x, playerEntity.move.newPosition.y, playerEntity.move.newPosition.z);
                var newPos = move * scaledMoveSpeed;
                
                playerEntity.transform.value.Translate(newPos);
                
                // playerEntity.RemoveMove();
                // return;
            }
        }
    }
}