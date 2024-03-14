using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [Enemy]
    public sealed class EnemyComponent : IComponent { }

    [Enemy, FlagPrefix("request")]
    public sealed class PlayerTargetComponent : IComponent { }

    [Enemy]
    public sealed class NavMeshAgentComponent : IComponent
    {
        public NavMeshAgent value;
    }

    [Enemy, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class FreezeAllEnemiesComponent : IComponent
    {
        public float timeToUnfreeze;
    }
    
    [Enemy, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class UnFreezeAllEnemiesComponent : IComponent { }

    [Enemy]
    public sealed class XpAwardComponent : IComponent
    {
        public int value;
    }
}