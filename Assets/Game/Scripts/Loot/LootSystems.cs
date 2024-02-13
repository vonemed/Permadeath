
namespace Loot
{
    public sealed class LootSystems : Entitas.Systems
    {
        public LootSystems(LootContext context)
        {
            Add(new LootFlyingSystem(context));
            Add(new LootPickUpSystem(context));
            
            Add(new LootEventSystems(Contexts.sharedInstance));
            Add(new LootCleanupSystems(Contexts.sharedInstance));
        }
    }
}