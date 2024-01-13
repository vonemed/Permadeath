//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity currentStateEntity { get { return GetGroup(GameMatcher.CurrentState).GetSingleEntity(); } }
    public Game.CurrentStateComponent currentState { get { return currentStateEntity.currentState; } }
    public bool hasCurrentState { get { return currentStateEntity != null; } }

    public GameEntity SetCurrentState(Game.GameCore.GameState newValue) {
        if (hasCurrentState) {
            throw new Entitas.EntitasException("Could not set CurrentState!\n" + this + " already has an entity with Game.CurrentStateComponent!",
                "You should check if the context already has a currentStateEntity before setting it or use context.ReplaceCurrentState().");
        }
        var entity = CreateEntity();
        entity.AddCurrentState(newValue);
        return entity;
    }

    public void ReplaceCurrentState(Game.GameCore.GameState newValue) {
        var entity = currentStateEntity;
        if (entity == null) {
            entity = SetCurrentState(newValue);
        } else {
            entity.ReplaceCurrentState(newValue);
        }
    }

    public void RemoveCurrentState() {
        currentStateEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.CurrentStateComponent currentState { get { return (Game.CurrentStateComponent)GetComponent(GameComponentsLookup.CurrentState); } }
    public bool hasCurrentState { get { return HasComponent(GameComponentsLookup.CurrentState); } }

    public void AddCurrentState(Game.GameCore.GameState newValue) {
        var index = GameComponentsLookup.CurrentState;
        var component = (Game.CurrentStateComponent)CreateComponent(index, typeof(Game.CurrentStateComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurrentState(Game.GameCore.GameState newValue) {
        var index = GameComponentsLookup.CurrentState;
        var component = (Game.CurrentStateComponent)CreateComponent(index, typeof(Game.CurrentStateComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentState() {
        RemoveComponent(GameComponentsLookup.CurrentState);
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

    static Entitas.IMatcher<GameEntity> _matcherCurrentState;

    public static Entitas.IMatcher<GameEntity> CurrentState {
        get {
            if (_matcherCurrentState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentState = matcher;
            }

            return _matcherCurrentState;
        }
    }
}