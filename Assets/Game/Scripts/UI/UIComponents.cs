using Entitas;
using Entitas.CodeGeneration.Attributes;
using Player;

namespace UI
{
    [UI, Unique]
    public sealed class DefeatPanelComponent : IComponent { }
    
    [UI, Unique]
    public sealed class CursedPanelComponent : IComponent { }

    [UI, Event(EventTarget.Self)]
    public sealed class CursedPanelBooster : IComponent
    {
        public PlayerBooster value;
    }
    
    [UI, Unique]
    public sealed class BoosterChoosePanelComponent : IComponent { }
    
    [UI, Unique]
    public sealed class StatsScreenComponent : IComponent { }
}