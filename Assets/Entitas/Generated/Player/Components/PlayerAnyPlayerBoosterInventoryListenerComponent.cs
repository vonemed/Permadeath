//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public AnyPlayerBoosterInventoryListenerComponent anyPlayerBoosterInventoryListener { get { return (AnyPlayerBoosterInventoryListenerComponent)GetComponent(PlayerComponentsLookup.AnyPlayerBoosterInventoryListener); } }
    public bool hasAnyPlayerBoosterInventoryListener { get { return HasComponent(PlayerComponentsLookup.AnyPlayerBoosterInventoryListener); } }

    public void AddAnyPlayerBoosterInventoryListener(System.Collections.Generic.List<IAnyPlayerBoosterInventoryListener> newValue) {
        var index = PlayerComponentsLookup.AnyPlayerBoosterInventoryListener;
        var component = (AnyPlayerBoosterInventoryListenerComponent)CreateComponent(index, typeof(AnyPlayerBoosterInventoryListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyPlayerBoosterInventoryListener(System.Collections.Generic.List<IAnyPlayerBoosterInventoryListener> newValue) {
        var index = PlayerComponentsLookup.AnyPlayerBoosterInventoryListener;
        var component = (AnyPlayerBoosterInventoryListenerComponent)CreateComponent(index, typeof(AnyPlayerBoosterInventoryListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyPlayerBoosterInventoryListener() {
        RemoveComponent(PlayerComponentsLookup.AnyPlayerBoosterInventoryListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PlayerMatcher {

    static Entitas.IMatcher<PlayerEntity> _matcherAnyPlayerBoosterInventoryListener;

    public static Entitas.IMatcher<PlayerEntity> AnyPlayerBoosterInventoryListener {
        get {
            if (_matcherAnyPlayerBoosterInventoryListener == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.AnyPlayerBoosterInventoryListener);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherAnyPlayerBoosterInventoryListener = matcher;
            }

            return _matcherAnyPlayerBoosterInventoryListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public void AddAnyPlayerBoosterInventoryListener(IAnyPlayerBoosterInventoryListener value) {
        var listeners = hasAnyPlayerBoosterInventoryListener
            ? anyPlayerBoosterInventoryListener.value
            : new System.Collections.Generic.List<IAnyPlayerBoosterInventoryListener>();
        listeners.Add(value);
        ReplaceAnyPlayerBoosterInventoryListener(listeners);
    }

    public void RemoveAnyPlayerBoosterInventoryListener(IAnyPlayerBoosterInventoryListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyPlayerBoosterInventoryListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyPlayerBoosterInventoryListener();
        } else {
            ReplaceAnyPlayerBoosterInventoryListener(listeners);
        }
    }
}
