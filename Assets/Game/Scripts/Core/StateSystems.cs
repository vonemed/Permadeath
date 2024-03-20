using Game;

namespace DefaultNamespace
{
    public sealed class StateSystems : Feature
    {
        public StateSystems(Contexts contexts)
        {
            //Init
            Add(new GameInitSystem());
            
            Add(new StateHandlerSystem(contexts.game));
            Add(new DefeatStateSystem(contexts.game));
            Add(new RestartStateSystem(contexts.game));
            Add(new PauseStateSystem(contexts.game));
            Add(new PlayStateSystem(contexts.game));
        }
    }
}