//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UIEntity {

    public CursedPanelBoosterListenerComponent cursedPanelBoosterListener { get { return (CursedPanelBoosterListenerComponent)GetComponent(UIComponentsLookup.CursedPanelBoosterListener); } }
    public bool hasCursedPanelBoosterListener { get { return HasComponent(UIComponentsLookup.CursedPanelBoosterListener); } }

    public void AddCursedPanelBoosterListener(System.Collections.Generic.List<ICursedPanelBoosterListener> newValue) {
        var index = UIComponentsLookup.CursedPanelBoosterListener;
        var component = (CursedPanelBoosterListenerComponent)CreateComponent(index, typeof(CursedPanelBoosterListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCursedPanelBoosterListener(System.Collections.Generic.List<ICursedPanelBoosterListener> newValue) {
        var index = UIComponentsLookup.CursedPanelBoosterListener;
        var component = (CursedPanelBoosterListenerComponent)CreateComponent(index, typeof(CursedPanelBoosterListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCursedPanelBoosterListener() {
        RemoveComponent(UIComponentsLookup.CursedPanelBoosterListener);
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
public sealed partial class UIMatcher {

    static Entitas.IMatcher<UIEntity> _matcherCursedPanelBoosterListener;

    public static Entitas.IMatcher<UIEntity> CursedPanelBoosterListener {
        get {
            if (_matcherCursedPanelBoosterListener == null) {
                var matcher = (Entitas.Matcher<UIEntity>)Entitas.Matcher<UIEntity>.AllOf(UIComponentsLookup.CursedPanelBoosterListener);
                matcher.componentNames = UIComponentsLookup.componentNames;
                _matcherCursedPanelBoosterListener = matcher;
            }

            return _matcherCursedPanelBoosterListener;
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
public partial class UIEntity {

    public void AddCursedPanelBoosterListener(ICursedPanelBoosterListener value) {
        var listeners = hasCursedPanelBoosterListener
            ? cursedPanelBoosterListener.value
            : new System.Collections.Generic.List<ICursedPanelBoosterListener>();
        listeners.Add(value);
        ReplaceCursedPanelBoosterListener(listeners);
    }

    public void RemoveCursedPanelBoosterListener(ICursedPanelBoosterListener value, bool removeComponentWhenEmpty = true) {
        var listeners = cursedPanelBoosterListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveCursedPanelBoosterListener();
        } else {
            ReplaceCursedPanelBoosterListener(listeners);
        }
    }
}