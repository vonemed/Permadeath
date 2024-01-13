using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Pools
{
    [ObjectPooler]
    public sealed class ObjectPoolComponent : IComponent { }
    
    [ObjectPooler, Unique]
    public sealed class EnemyPoolComponent : IComponent { }
    
    [ObjectPooler, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class SpawnObjectsComponent : IComponent { }
    
}