namespace Pools
{
    public sealed class PoolSystems : Entitas.Systems
    {
        public PoolSystems(Contexts contexts)
        {
            Add(new EnemyPoolSystems(contexts.objectPooler));

            Add(new ObjectPoolerEventSystems(contexts));
            Add(new ObjectPoolerCleanupSystems(contexts));
        }
    }
}