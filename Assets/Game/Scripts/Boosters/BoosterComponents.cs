using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Boosters
{


    [Booster, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class BoosterSelectedComponent : IComponent
    {
        public int boosterHash;
    }
    
    [Booster]
    public sealed class BoosterComponent : IComponent { }

    [Booster]
    public sealed class BoosterIndexComponent : IComponent
    {
        [PrimaryEntityIndex] public int value;
    }

    [Booster, Event(EventTarget.Self)]
    public sealed class CursedComponent : IComponent { }

    [Booster]
    public sealed class BoosterTypeComponent : IComponent
    {
        // public BoosterType value;
    }
}