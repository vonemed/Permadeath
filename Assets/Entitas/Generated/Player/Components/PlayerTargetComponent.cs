//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public Game.TargetComponent target { get { return (Game.TargetComponent)GetComponent(PlayerComponentsLookup.Target); } }
    public bool hasTarget { get { return HasComponent(PlayerComponentsLookup.Target); } }

    public void AddTarget(UnityEngine.Transform newValue) {
        var index = PlayerComponentsLookup.Target;
        var component = (Game.TargetComponent)CreateComponent(index, typeof(Game.TargetComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTarget(UnityEngine.Transform newValue) {
        var index = PlayerComponentsLookup.Target;
        var component = (Game.TargetComponent)CreateComponent(index, typeof(Game.TargetComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTarget() {
        RemoveComponent(PlayerComponentsLookup.Target);
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
public partial class PlayerEntity : ITargetEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PlayerMatcher {

    static Entitas.IMatcher<PlayerEntity> _matcherTarget;

    public static Entitas.IMatcher<PlayerEntity> Target {
        get {
            if (_matcherTarget == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.Target);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherTarget = matcher;
            }

            return _matcherTarget;
        }
    }
}