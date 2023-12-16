using Entitas;
using UnityEngine;

namespace Game
{
    [Player, Game]
    public sealed class TransformComponent : IComponent
    {
        public Transform value;
    }
}