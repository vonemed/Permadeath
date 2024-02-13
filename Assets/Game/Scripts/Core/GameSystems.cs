using Boosters;
using Entitas;
using Projectiles;

namespace Game
{
    public sealed class GameSystems : Systems
    {
        public GameSystems(Contexts contexts)
        {
            //Init
            Add(new GameInitSystem());
            
            //States //todo: group them into a feature
            Add(new StateHandlerSystem(contexts.game));
            Add(new DefeatStateSystem(contexts.game));
            Add(new RestartStateSystem(contexts.game));
            Add(new PauseStateSystem(contexts.game));
            Add(new PlayStateSystem(contexts.game));

            Add(new ProjectileSystems(contexts));
            Add(new BoosterSystems(contexts.booster));

            //Event
            Add(new GameEventSystems(contexts));

            //Cleanup
            Add(new GameCleanupSystems(contexts));
        }
    }
}