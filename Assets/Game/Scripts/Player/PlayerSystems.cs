using Player.Systems;
using Entitas;

namespace Player
{
    public sealed class PlayerSystems : Entitas.Systems
    {
        public PlayerSystems(Contexts contexts)
        {
            Add(new PlayerAttackRateSystem());
            
            
            Add(new PlayerDetectionSystem(contexts));
            Add(new PlayerAttackSystem(contexts.player));

            Add(new PlayerDeathSystem(contexts.player));
            Add(new PlayerXpSystem(contexts.player));

            Add(new PlayerInventoryUpdateSystem(contexts.player));
            
            Add(new PlayerEventSystems(contexts));
            // Add(new PlayerReactiveMovementSystem(contexts.player));
            // Add(new PlayerMovementSystem(contexts));

        }
    }
}