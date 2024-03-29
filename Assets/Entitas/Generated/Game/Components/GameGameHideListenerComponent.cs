//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameHideListenerComponent gameHideListener { get { return (GameHideListenerComponent)GetComponent(GameComponentsLookup.GameHideListener); } }
    public bool hasGameHideListener { get { return HasComponent(GameComponentsLookup.GameHideListener); } }

    public void AddGameHideListener(System.Collections.Generic.List<IGameHideListener> newValue) {
        var index = GameComponentsLookup.GameHideListener;
        var component = (GameHideListenerComponent)CreateComponent(index, typeof(GameHideListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameHideListener(System.Collections.Generic.List<IGameHideListener> newValue) {
        var index = GameComponentsLookup.GameHideListener;
        var component = (GameHideListenerComponent)CreateComponent(index, typeof(GameHideListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameHideListener() {
        RemoveComponent(GameComponentsLookup.GameHideListener);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameHideListener;

    public static Entitas.IMatcher<GameEntity> GameHideListener {
        get {
            if (_matcherGameHideListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameHideListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameHideListener = matcher;
            }

            return _matcherGameHideListener;
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
public partial class GameEntity {

    public void AddGameHideListener(IGameHideListener value) {
        var listeners = hasGameHideListener
            ? gameHideListener.value
            : new System.Collections.Generic.List<IGameHideListener>();
        listeners.Add(value);
        ReplaceGameHideListener(listeners);
    }

    public void RemoveGameHideListener(IGameHideListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameHideListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameHideListener();
        } else {
            ReplaceGameHideListener(listeners);
        }
    }
}
