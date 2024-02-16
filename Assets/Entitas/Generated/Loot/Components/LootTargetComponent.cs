//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LootEntity {

    public Game.TargetComponent target { get { return (Game.TargetComponent)GetComponent(LootComponentsLookup.Target); } }
    public bool hasTarget { get { return HasComponent(LootComponentsLookup.Target); } }

    public void AddTarget(UnityEngine.Transform newValue) {
        var index = LootComponentsLookup.Target;
        var component = (Game.TargetComponent)CreateComponent(index, typeof(Game.TargetComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTarget(UnityEngine.Transform newValue) {
        var index = LootComponentsLookup.Target;
        var component = (Game.TargetComponent)CreateComponent(index, typeof(Game.TargetComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTarget() {
        RemoveComponent(LootComponentsLookup.Target);
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
public partial class LootEntity : ITargetEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class LootMatcher {

    static Entitas.IMatcher<LootEntity> _matcherTarget;

    public static Entitas.IMatcher<LootEntity> Target {
        get {
            if (_matcherTarget == null) {
                var matcher = (Entitas.Matcher<LootEntity>)Entitas.Matcher<LootEntity>.AllOf(LootComponentsLookup.Target);
                matcher.componentNames = LootComponentsLookup.componentNames;
                _matcherTarget = matcher;
            }

            return _matcherTarget;
        }
    }
}