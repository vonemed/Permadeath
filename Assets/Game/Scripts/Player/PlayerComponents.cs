using System;
using System.Collections.Generic;
using Boosters;
using DefaultNamespace;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Player
{
    [Serializable]
    public sealed class PlayerBooster
    {
        public int level;
        public bool cursed;
        public int id;
    }
    
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

    [Serializable]
    public class BoosterInfo
    {
        public BoosterScriptable booster;
        public uint amount;
    }

    [Player, Event(EventTarget.Any)]
    public sealed class PlayerBoosterInventoryComponent : IComponent
    {
        public List<PlayerBooster> value = new List<PlayerBooster>();
    }
    
    [Player]
    public sealed class PermaDeathComponent : IComponent { }
}