namespace Enemies
{
    public sealed class EnemySystems : Entitas.Systems
    {
        public EnemySystems(Contexts contexts)
        {
            Add(new SetPlayerTargetSystem(contexts.enemy));
            Add(new EnemyMovementSystem(contexts.enemy));

            //Attack
            Add(new EnemyAttackRateSystem(contexts.enemy));
            Add(new EnemyAttackSystem(contexts.enemy));

            Add(new EnemyDeathSystem(contexts.enemy));
            
            Add(new EnemyFreezeSystem(contexts.enemy));
            
            Add(new EnemyEventSystems(contexts));

        }
    }
}