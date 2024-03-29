//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ObjectPoolerEntity {

    public Game.TransformComponent transform { get { return (Game.TransformComponent)GetComponent(ObjectPoolerComponentsLookup.Transform); } }
    public bool hasTransform { get { return HasComponent(ObjectPoolerComponentsLookup.Transform); } }

    public void AddTransform(UnityEngine.Transform newValue) {
        var index = ObjectPoolerComponentsLookup.Transform;
        var component = (Game.TransformComponent)CreateComponent(index, typeof(Game.TransformComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTransform(UnityEngine.Transform newValue) {
        var index = ObjectPoolerComponentsLookup.Transform;
        var component = (Game.TransformComponent)CreateComponent(index, typeof(Game.TransformComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTransform() {
        RemoveComponent(ObjectPoolerComponentsLookup.Transform);
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
public partial class ObjectPoolerEntity : ITransformEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ObjectPoolerMatcher {

    static Entitas.IMatcher<ObjectPoolerEntity> _matcherTransform;

    public static Entitas.IMatcher<ObjectPoolerEntity> Transform {
        get {
            if (_matcherTransform == null) {
                var matcher = (Entitas.Matcher<ObjectPoolerEntity>)Entitas.Matcher<ObjectPoolerEntity>.AllOf(ObjectPoolerComponentsLookup.Transform);
                matcher.componentNames = ObjectPoolerComponentsLookup.componentNames;
                _matcherTransform = matcher;
            }

            return _matcherTransform;
        }
    }
}
