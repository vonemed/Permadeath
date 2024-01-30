
namespace Pools
{
    public class EnemyPoolSystems : Feature
    {
        public EnemyPoolSystems(ObjectPoolerContext context)
        {
            Add(new EnemyPoolTimerSystem(context));
            Add(new EnemySpawnSystem(context));
        }
    }
}