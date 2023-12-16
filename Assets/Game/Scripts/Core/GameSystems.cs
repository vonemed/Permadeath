using Entitas;
using Player;

namespace Game
{
    public class GameSystems : Systems
    {
        public GameSystems(Contexts contexts)
        {
            Add(new PlayerSystems(contexts));
        }
    }
}