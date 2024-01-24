using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Projectiles
{
    [Game]
    public sealed class ProjectileComponent : IComponent { }
    
    [Game, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class OffComponent : IComponent { }
}