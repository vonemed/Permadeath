using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    #region Movement

    [Player, Game, Enemy, ObjectPooler, Loot]
    public sealed class TransformComponent : IComponent
    {
        public Transform value;
    }

    [Player, Enemy, Game]
    public sealed class RigidbodyComponent : IComponent
    {
        public Rigidbody value;
    }

    [Player, Enemy, Game]
    public sealed class MovementSpeedComponent : IComponent
    {
        public float value;
    }

    [Game]
    public sealed class MoveDirectionComponent : IComponent
    {
        public Vector3 value;
    }

    #endregion

    #region Stats

    [Player, Enemy, Event(EventTarget.Any)]
    public sealed class HealthComponent : IComponent
    {
        public float value;
    }

    [Player, Enemy]
    public sealed class HealthRegenComponent : IComponent
    {
        public float value;
    }

    [Player, Enemy, Event(EventTarget.Any)]
    public sealed class LevelComponent : IComponent
    {
        public uint value;
    }

    [Player, Enemy, Game]
    public sealed class DamageComponent : IComponent
    {
        public float value;
    }

    [Player, Enemy]
    public sealed class AttackRateComponent : IComponent
    {
        public float value;
    }

    [Player, Enemy]
    public sealed class AttackRangeComponent : IComponent
    {
        public float value;
    }

    [Player, Enemy]
    public sealed class DefenceComponent : IComponent
    {
        public float value;
    }

    #endregion


    #region Combat

    [Player, Enemy, Game, Loot]
    public sealed class TargetComponent : IComponent
    {
        public Transform value;
    }


    [Enemy, Player, FlagPrefix("request")]
    public sealed class AttackComponent : IComponent
    {
    }

    #endregion

    #region StatusEffects

    [Player, Enemy]
    public sealed class DeathComponent : IComponent
    {
    }

    [Player, Enemy]
    public sealed class FreezeComponent : IComponent
    {
    }
    
    [Player, Enemy, Game, ObjectPooler, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class ResetComponent : IComponent { }
    
    [Enemy, Event(EventTarget.Self)]
    public sealed class SpawnedComponent : IComponent { }

    #endregion


    #region State

    //Core
    [Game, Unique]
    public sealed class StateHandlerComponent : IComponent
    {
    }

    [Game, Unique]
    public sealed class CurrentStateComponent : IComponent
    {
        public GameCore.GameState value;
    }

    [Player, Enemy]
    public sealed class PausedComponent : IComponent
    {
    }

    [Game, FlagPrefix("request"), Cleanup(CleanupMode.DestroyEntity)]
    public sealed class DefeatComponent : IComponent
    {
    }

    [Game, FlagPrefix("request"), Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RestartComponent : IComponent
    {
    }

    [Game, FlagPrefix("request"), Cleanup(CleanupMode.DestroyEntity)]
    public sealed class PauseComponent : IComponent
    {
    }

    [Game, FlagPrefix("request"), Cleanup(CleanupMode.DestroyEntity)]
    public sealed class PlayComponent : IComponent
    {
    }

    #endregion

    #region UI

    [UI, GameUI, Game, Loot, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class ShowComponent : IComponent
    {
    }

    [UI,GameUI, Game, Loot, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class HideComponent : IComponent
    {
    }

    #endregion
}