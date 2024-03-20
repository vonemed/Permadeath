using Boosters;
using CoreSystems;
using Entitas;
using Projectiles;

namespace Game
{
    public sealed class GameSystems : Systems
    {
        public GameSystems(Contexts contexts)
        {
            Add(new KeyboardSystem(contexts));

            Add(new ProjectileSystems(contexts));
            Add(new BoosterSystems(contexts.booster));

            //Event
            Add(new GameEventSystems(contexts));

            //Cleanup
            Add(new GameCleanupSystems(contexts));
        }
    }
}