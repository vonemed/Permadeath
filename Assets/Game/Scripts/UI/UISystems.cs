using Entitas;

namespace UI
{
    public sealed class UISystems : Systems
    {
        public UISystems(Contexts contexts)
        {
            Add(new UIEventSystems(contexts));
            Add(new UICleanupSystems(contexts));
        }
    }
}