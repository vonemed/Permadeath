using Entitas;

namespace UI.GameUI
{
    public sealed class GameUISystems : Systems
    {
        public GameUISystems(Contexts contexts)
        {
            Add(new GameUIEventSystems(contexts));
            Add(new GameUICleanupSystems(contexts));
        }
    }
}