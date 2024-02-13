using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Boosters
{
    [Booster, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class BoosterSelectedComponent : IComponent
    {
        public BoosterStats boosterStats;
    }
}