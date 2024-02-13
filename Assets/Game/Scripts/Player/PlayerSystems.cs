using Player.Systems;
using Entitas;

namespace Player
{
    public sealed class PlayerSystems : Entitas.Systems
    {
        public PlayerSystems(Contexts contexts)
        {
            Add(new PlayerAttackRateSystem());
            
            Add(new PlayerMovementSystem(contexts));
            
            Add(new PlayerDetectionSystem(contexts));
            Add(new PlayerAttackSystem(contexts.player));

            Add(new PlayerDeathSystem(contexts.player));
            Add(new PlayerXpSystem(contexts.player));
            
            Add(new PlayerEventSystems(contexts));
        }
    }
}