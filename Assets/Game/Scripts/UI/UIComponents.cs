using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace UI
{
    [UI, Unique]
    public sealed class DefeatPanelComponent : IComponent { }
    
    [UI, Unique]
    public sealed class StatsScreenComponent : IComponent { }
    
    [UI, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class ShowComponent : IComponent { }
    
    [UI, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class HideComponent : IComponent { }
}