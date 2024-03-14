using Boosters;
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
                if (playerEntity.move.newPosition.sqrMagnitude == 0 || playerEntity.isPermaDeath)
                    return;

                // var scaledMoveSpeed = playerEntity.playerStats.value.moveSpeed * Time.deltaTime;
                // // For simplicity's sake, we just keep movement in a single plane here. Rotate
                // // direction according to world Y rotation of player.
                // var move = new Vector3(playerEntity.move.newPosition.x, playerEntity.move.newPosition.y, playerEntity.move.newPosition.z);
                // var newPos = move * scaledMoveSpeed;
                
                // playerEntity.transform.value.GetComponent<Rigidbody>().MovePosition(newPos);
                // playerEntity.transform.value.Translate(newPos);
                
                var move = new Vector3(playerEntity.move.newPosition.x, 0, playerEntity.move.newPosition.z);
                var scaledMoveSpeed =  playerEntity.playerStats.value.GetStat(BoosterEnums.PlayerStatType.MoveSpeed) * Time.deltaTime;
                var newPos = move * scaledMoveSpeed;
                
                playerEntity.rigidbody.value.MovePosition(playerEntity.transform.value.position + newPos);
                
                // playerEntity.RemoveMove();
                // return;
            }
        }
    }
}