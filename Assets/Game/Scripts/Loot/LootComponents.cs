using Entitas;

namespace Loot
{
    [Loot]
    public sealed class LootComponent : IComponent { }

    [Loot]
    public sealed class LootRewardComponent : IComponent
    {
        public Loot.Reward value;
    }
    
    [Loot]
    public sealed class PickedUpComponent : IComponent { }
    
    [Loot]
    public sealed class SpawnedComponent : IComponent { }

    [Loot]
    public sealed class FlyToTargetComponent : IComponent { }
}