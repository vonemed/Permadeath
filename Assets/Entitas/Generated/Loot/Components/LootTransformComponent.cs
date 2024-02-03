//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LootEntity {

    public Game.TransformComponent transform { get { return (Game.TransformComponent)GetComponent(LootComponentsLookup.Transform); } }
    public bool hasTransform { get { return HasComponent(LootComponentsLookup.Transform); } }

    public void AddTransform(UnityEngine.Transform newValue) {
        var index = LootComponentsLookup.Transform;
        var component = (Game.TransformComponent)CreateComponent(index, typeof(Game.TransformComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTransform(UnityEngine.Transform newValue) {
        var index = LootComponentsLookup.Transform;
        var component = (Game.TransformComponent)CreateComponent(index, typeof(Game.TransformComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTransform() {
        RemoveComponent(LootComponentsLookup.Transform);
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
public partial class LootEntity : ITransformEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class LootMatcher {

    static Entitas.IMatcher<LootEntity> _matcherTransform;

    public static Entitas.IMatcher<LootEntity> Transform {
        get {
            if (_matcherTransform == null) {
                var matcher = (Entitas.Matcher<LootEntity>)Entitas.Matcher<LootEntity>.AllOf(LootComponentsLookup.Transform);
                matcher.componentNames = LootComponentsLookup.componentNames;
                _matcherTransform = matcher;
            }

            return _matcherTransform;
        }
    }
}
