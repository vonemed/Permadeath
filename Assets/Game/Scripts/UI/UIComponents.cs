using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace UI
{
    [UI, Unique]
    public sealed class DefeatPanelComponent : IComponent { }
    
    [UI, Unique]
    public sealed class StatsScreenComponent : IComponent { }
}