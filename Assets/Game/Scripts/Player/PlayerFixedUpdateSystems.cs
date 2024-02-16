using Player.Systems;

namespace Player
{
    public class PlayerFixedUpdateSystems : Entitas.Systems
    {
        public PlayerFixedUpdateSystems(Contexts contexts)
        {
            Add(new PlayerMovementSystem(contexts));
        }
    }
}