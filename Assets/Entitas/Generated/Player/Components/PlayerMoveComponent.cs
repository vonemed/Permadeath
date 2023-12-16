//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public Player.MoveComponent move { get { return (Player.MoveComponent)GetComponent(PlayerComponentsLookup.Move); } }
    public bool hasMove { get { return HasComponent(PlayerComponentsLookup.Move); } }

    public void AddMove(UnityEngine.Vector3 newNewPosition) {
        var index = PlayerComponentsLookup.Move;
        var component = (Player.MoveComponent)CreateComponent(index, typeof(Player.MoveComponent));
        component.newPosition = newNewPosition;
        AddComponent(index, component);
    }

    public void ReplaceMove(UnityEngine.Vector3 newNewPosition) {
        var index = PlayerComponentsLookup.Move;
        var component = (Player.MoveComponent)CreateComponent(index, typeof(Player.MoveComponent));
        component.newPosition = newNewPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveMove() {
        RemoveComponent(PlayerComponentsLookup.Move);
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

    static Entitas.IMatcher<PlayerEntity> _matcherMove;

    public static Entitas.IMatcher<PlayerEntity> Move {
        get {
            if (_matcherMove == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.Move);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherMove = matcher;
            }

            return _matcherMove;
        }
    }
}