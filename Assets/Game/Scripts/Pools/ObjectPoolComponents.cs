using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Pools
{
    [ObjectPooler]
    public sealed class ObjectPoolComponent : IComponent { }
    
    [ObjectPooler, Unique]
    public sealed class EnemyPoolComponent : IComponent { }

    [ObjectPooler]
    public sealed class CurrentWaveComponent : IComponent
    {
        public int value;
    }
    
    [ObjectPooler]
    public sealed class NextWaveTimerComponent : IComponent
    {
        public float value;
    }

    [ObjectPooler]
    public sealed class EnemyWavesComponent : IComponent
    {
        public List<EnemyPooler.EnemyData> value = new List<EnemyPooler.EnemyData>();
    }
    
    [ObjectPooler, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class SpawnObjectsComponent : IComponent { }
    
}