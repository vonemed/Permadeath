using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [Enemy]
    public sealed class EnemyComponent : IComponent { }

    [Enemy]
    public sealed class EnemyTargetComponent : IComponent
    {
        public Transform value;
    }
    
    [Enemy, FlagPrefix("request")]
    public sealed class PlayerTargetComponent : IComponent { }
    
    [Enemy, FlagPrefix("request")]
    public sealed class EnemyAttackComponent : IComponent { }

    [Enemy]
    public sealed class NavMeshAgentComponent : IComponent
    {
        public NavMeshAgent value;
    }
}