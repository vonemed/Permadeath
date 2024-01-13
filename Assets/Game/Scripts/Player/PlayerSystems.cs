using Player.Systems;

namespace Player
{
    public class PlayerSystems : Feature
    {
        public PlayerSystems(Contexts contexts)
        {
            Add(new PlayerMovementSystem(contexts));

            Add(new PlayerDeathSystem(contexts.player));
        }
    }
}