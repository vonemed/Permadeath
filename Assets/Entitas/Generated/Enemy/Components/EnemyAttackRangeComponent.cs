//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemyEntity {

    public Game.AttackRangeComponent attackRange { get { return (Game.AttackRangeComponent)GetComponent(EnemyComponentsLookup.AttackRange); } }
    public bool hasAttackRange { get { return HasComponent(EnemyComponentsLookup.AttackRange); } }

    public void AddAttackRange(float newValue) {
        var index = EnemyComponentsLookup.AttackRange;
        var component = (Game.AttackRangeComponent)CreateComponent(index, typeof(Game.AttackRangeComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAttackRange(float newValue) {
        var index = EnemyComponentsLookup.AttackRange;
        var component = (Game.AttackRangeComponent)CreateComponent(index, typeof(Game.AttackRangeComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAttackRange() {
        RemoveComponent(EnemyComponentsLookup.AttackRange);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemyEntity : IAttackRangeEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class EnemyMatcher {

    static Entitas.IMatcher<EnemyEntity> _matcherAttackRange;

    public static Entitas.IMatcher<EnemyEntity> AttackRange {
        get {
            if (_matcherAttackRange == null) {
                var matcher = (Entitas.Matcher<EnemyEntity>)Entitas.Matcher<EnemyEntity>.AllOf(EnemyComponentsLookup.AttackRange);
                matcher.componentNames = EnemyComponentsLookup.componentNames;
                _matcherAttackRange = matcher;
            }

            return _matcherAttackRange;
        }
    }
}
