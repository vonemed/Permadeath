using Enemies;
using Entitas;
using Player;
using Projectiles;

namespace Game
{
    public sealed class GameSystems : Systems
    {
        public GameSystems(Contexts contexts)
        {
            //Init
            Add(new GameInitSystem());
            
            //States
            Add(new StateHandlerSystem(contexts.game));
            Add(new DefeatStateSystem(contexts.game));
            Add(new RestartStateSystem(contexts.game));

            Add(new PlayerSystems(contexts));
            Add(new EnemySystems(contexts));

            Add(new ProjectileSystems(contexts));

            //Event
            Add(new UIEventSystems(contexts));
            Add(new ObjectPoolerEventSystems(contexts));
            Add(new GameEventSystems(contexts));
            
            //Cleanup
            Add(new GameCleanupSystems(contexts));
            Add(new ObjectPoolerCleanupSystems(contexts));
        }
    }
}