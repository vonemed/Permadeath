
namespace Loot
{
    public class LootSystems : Feature
    {
        public LootSystems(LootContext context)
        {
            Add(new LootFlyingSystem(context));
            Add(new LootPickUpSystem(context));
        }
    }
}