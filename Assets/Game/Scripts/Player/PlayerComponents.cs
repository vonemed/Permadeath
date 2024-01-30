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
    
    
}