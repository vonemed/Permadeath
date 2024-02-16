using Boosters.Systems;

namespace Boosters
{
    public sealed class BoosterSystems : Feature
    {
        public BoosterSystems(BoosterContext context)
        {
            Add(new BoosterIsChosenSystem(context));
            Add(new HealthRegenSystem(context));
        }
    }
}