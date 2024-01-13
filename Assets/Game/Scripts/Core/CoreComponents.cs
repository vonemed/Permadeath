using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    #region Movement
    [Player, Game, Enemy]
    public sealed class TransformComponent : IComponent
    {
        public Transform value;
    }
    
    [Player, Enemy]
    public sealed class MovementSpeedComponent : IComponent
    {
        public float value;
    }
    
    #endregion

    [Player, Enemy]
    public sealed class HealthComponent : IComponent
    {
        public int value;
    }

    #region Combat
    [Player, Enemy]
    public sealed class DamageComponent : IComponent
    {
        public int value;
    }
    
    [Player, Enemy]
    public sealed class AttackRateComponent : IComponent
    {
        public float value;
    }
    
    #endregion
    
    [Player, Enemy]
    public sealed class DeathComponent : IComponent { }
    
    //Core
    [Game, Unique]
    public sealed class StateHandlerComponent : IComponent {}

    [Game, Unique]
    public sealed class CurrentStateComponent : IComponent
    {
        public GameCore.GameState value;
    }
    
    [Game, FlagPrefix("request"), Cleanup(CleanupMode.DestroyEntity)]
    public sealed class DefeatComponent : IComponent { }
    
    [Game, FlagPrefix("request"), Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RestartComponent : IComponent { }
}