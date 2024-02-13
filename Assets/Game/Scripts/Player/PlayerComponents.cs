using System.Collections.Generic;
using Boosters;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Player
{
    [Player, Unique]
    public sealed class BaseComponent : IComponent { }
    
    [Player, Event(EventTarget.Any)]
    public sealed class XpComponent : IComponent
    {
        public int value;
    }
    
    [Player]
    public sealed class MoveComponent : IComponent
    {
        public Vector3 newPosition;
    }

    [Player]
    public sealed class PlayerStatsComponent : IComponent
    {
        public PlayerConfig.PlayerStats value;
    }

    [Player]
    public sealed class PlayerAttackSpeedCooldownComponent : IComponent
    {
        public float value;
    }

    [Player, Event(EventTarget.Any)]
    public sealed class PlayerBoosterInventoryComponent : IComponent
    {
        public List<Booster> value = new List<Booster>();
    }
}