namespace Enemies
{
    public class EnemySystems : Feature
    {
        public EnemySystems(Contexts contexts)
        {
            Add(new SetPlayerTargetSystem(contexts.enemy));
            Add(new EnemyMovementSystem(contexts.enemy));

            //Attack
            Add(new EnemyAttackRateSystem(contexts.enemy));
            Add(new EnemyAttackSystem(contexts.enemy));
        }
    }
}