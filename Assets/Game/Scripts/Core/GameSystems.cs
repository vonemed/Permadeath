using Enemies;
using Entitas;
using Loot;
using Player;
using Pools;
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

            Add(new EnemyPoolSystems(contexts.objectPooler));

            Add(new LootSystems(contexts.loot));

            //Event
            Add(new UIEventSystems(contexts));
            Add(new ObjectPoolerEventSystems(contexts));
            Add(new GameEventSystems(contexts));
            Add(new PlayerEventSystems(contexts));
            Add(new LootEventSystems(contexts));

            //Cleanup
            Add(new GameCleanupSystems(contexts));
            Add(new ObjectPoolerCleanupSystems(contexts));
            Add(new LootCleanupSystems(contexts));
        }
    }
}