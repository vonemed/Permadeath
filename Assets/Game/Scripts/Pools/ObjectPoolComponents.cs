using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

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
    
    [ObjectPooler]
    public sealed class SpawnedObjectsComponent : IComponent
    {
        public List<EnemyPooler.SpawnedObject> value = new List<EnemyPooler.SpawnedObject>();
    }
    
    [ObjectPooler, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class SpawnObjectsComponent : IComponent { }
    
}