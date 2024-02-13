//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class EnemyComponentsLookup {

    public const int Enemy = 0;
    public const int NavMeshAgent = 1;
    public const int PlayerTarget = 2;
    public const int XpAward = 3;
    public const int EnemyAnyHealthListener = 4;
    public const int EnemyAnyLevelListener = 5;
    public const int Attack = 6;
    public const int AttackRange = 7;
    public const int AttackRate = 8;
    public const int Damage = 9;
    public const int Death = 10;
    public const int Health = 11;
    public const int HealthRegen = 12;
    public const int Level = 13;
    public const int MovementSpeed = 14;
    public const int Paused = 15;
    public const int Target = 16;
    public const int Transform = 17;

    public const int TotalComponents = 18;

    public static readonly string[] componentNames = {
        "Enemy",
        "NavMeshAgent",
        "PlayerTarget",
        "XpAward",
        "EnemyAnyHealthListener",
        "EnemyAnyLevelListener",
        "Attack",
        "AttackRange",
        "AttackRate",
        "Damage",
        "Death",
        "Health",
        "HealthRegen",
        "Level",
        "MovementSpeed",
        "Paused",
        "Target",
        "Transform"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Enemies.EnemyComponent),
        typeof(Enemies.NavMeshAgentComponent),
        typeof(Enemies.PlayerTargetComponent),
        typeof(Enemies.XpAwardComponent),
        typeof(EnemyAnyHealthListenerComponent),
        typeof(EnemyAnyLevelListenerComponent),
        typeof(Game.AttackComponent),
        typeof(Game.AttackRangeComponent),
        typeof(Game.AttackRateComponent),
        typeof(Game.DamageComponent),
        typeof(Game.DeathComponent),
        typeof(Game.HealthComponent),
        typeof(Game.HealthRegenComponent),
        typeof(Game.LevelComponent),
        typeof(Game.MovementSpeedComponent),
        typeof(Game.PausedComponent),
        typeof(Game.TargetComponent),
        typeof(Game.TransformComponent)
    };
}
