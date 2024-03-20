using Entitas;

namespace DefaultNamespace
{
    public sealed class MainMenuSystems : Systems
    {
        public MainMenuSystems(Contexts contexts)
        {
            Add(new StateSystems(contexts));
        }
    }
}