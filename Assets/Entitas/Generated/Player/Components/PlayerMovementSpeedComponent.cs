//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public Game.MovementSpeedComponent movementSpeed { get { return (Game.MovementSpeedComponent)GetComponent(PlayerComponentsLookup.MovementSpeed); } }
    public bool hasMovementSpeed { get { return HasComponent(PlayerComponentsLookup.MovementSpeed); } }

    public void AddMovementSpeed(float newValue) {
        var index = PlayerComponentsLookup.MovementSpeed;
        var component = (Game.MovementSpeedComponent)CreateComponent(index, typeof(Game.MovementSpeedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMovementSpeed(float newValue) {
        var index = PlayerComponentsLookup.MovementSpeed;
        var component = (Game.MovementSpeedComponent)CreateComponent(index, typeof(Game.MovementSpeedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMovementSpeed() {
        RemoveComponent(PlayerComponentsLookup.MovementSpeed);
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
public partial class PlayerEntity : IMovementSpeedEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PlayerMatcher {

    static Entitas.IMatcher<PlayerEntity> _matcherMovementSpeed;

    public static Entitas.IMatcher<PlayerEntity> MovementSpeed {
        get {
            if (_matcherMovementSpeed == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.MovementSpeed);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherMovementSpeed = matcher;
            }

            return _matcherMovementSpeed;
        }
    }
}
