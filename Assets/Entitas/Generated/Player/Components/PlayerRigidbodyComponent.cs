//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public Game.RigidbodyComponent rigidbody { get { return (Game.RigidbodyComponent)GetComponent(PlayerComponentsLookup.Rigidbody); } }
    public bool hasRigidbody { get { return HasComponent(PlayerComponentsLookup.Rigidbody); } }

    public void AddRigidbody(UnityEngine.Rigidbody newValue) {
        var index = PlayerComponentsLookup.Rigidbody;
        var component = (Game.RigidbodyComponent)CreateComponent(index, typeof(Game.RigidbodyComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRigidbody(UnityEngine.Rigidbody newValue) {
        var index = PlayerComponentsLookup.Rigidbody;
        var component = (Game.RigidbodyComponent)CreateComponent(index, typeof(Game.RigidbodyComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRigidbody() {
        RemoveComponent(PlayerComponentsLookup.Rigidbody);
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
public partial class PlayerEntity : IRigidbodyEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PlayerMatcher {

    static Entitas.IMatcher<PlayerEntity> _matcherRigidbody;

    public static Entitas.IMatcher<PlayerEntity> Rigidbody {
        get {
            if (_matcherRigidbody == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.Rigidbody);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherRigidbody = matcher;
            }

            return _matcherRigidbody;
        }
    }
}
