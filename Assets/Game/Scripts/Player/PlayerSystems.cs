using Player.Systems;

namespace Player
{
    public class PlayerSystems : Feature
    {
        public PlayerSystems(Contexts contexts)
        {
            Add(new PlayerAttackRateSystem());
            
            Add(new PlayerMovementSystem(contexts));
            
            Add(new PlayerDetectionSystem(contexts));
            Add(new PlayerAttackSystem(contexts.player));

            Add(new PlayerDeathSystem(contexts.player));
        }
    }
}