//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemyEntity {

    public Game.TargetComponent target { get { return (Game.TargetComponent)GetComponent(EnemyComponentsLookup.Target); } }
    public bool hasTarget { get { return HasComponent(EnemyComponentsLookup.Target); } }

    public void AddTarget(UnityEngine.Transform newValue) {
        var index = EnemyComponentsLookup.Target;
        var component = (Game.TargetComponent)CreateComponent(index, typeof(Game.TargetComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTarget(UnityEngine.Transform newValue) {
        var index = EnemyComponentsLookup.Target;
        var component = (Game.TargetComponent)CreateComponent(index, typeof(Game.TargetComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTarget() {
        RemoveComponent(EnemyComponentsLookup.Target);
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
public partial class EnemyEntity : ITargetEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class EnemyMatcher {

    static Entitas.IMatcher<EnemyEntity> _matcherTarget;

    public static Entitas.IMatcher<EnemyEntity> Target {
        get {
            if (_matcherTarget == null) {
                var matcher = (Entitas.Matcher<EnemyEntity>)Entitas.Matcher<EnemyEntity>.AllOf(EnemyComponentsLookup.Target);
                matcher.componentNames = EnemyComponentsLookup.componentNames;
                _matcherTarget = matcher;
            }

            return _matcherTarget;
        }
    }
}