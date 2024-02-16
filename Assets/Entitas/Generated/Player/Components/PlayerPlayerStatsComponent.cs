//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public Player.PlayerStatsComponent playerStats { get { return (Player.PlayerStatsComponent)GetComponent(PlayerComponentsLookup.PlayerStats); } }
    public bool hasPlayerStats { get { return HasComponent(PlayerComponentsLookup.PlayerStats); } }

    public void AddPlayerStats(PlayerConfig.PlayerStats newValue) {
        var index = PlayerComponentsLookup.PlayerStats;
        var component = (Player.PlayerStatsComponent)CreateComponent(index, typeof(Player.PlayerStatsComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerStats(PlayerConfig.PlayerStats newValue) {
        var index = PlayerComponentsLookup.PlayerStats;
        var component = (Player.PlayerStatsComponent)CreateComponent(index, typeof(Player.PlayerStatsComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerStats() {
        RemoveComponent(PlayerComponentsLookup.PlayerStats);
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

    static Entitas.IMatcher<PlayerEntity> _matcherPlayerStats;

    public static Entitas.IMatcher<PlayerEntity> PlayerStats {
        get {
            if (_matcherPlayerStats == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.PlayerStats);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherPlayerStats = matcher;
            }

            return _matcherPlayerStats;
        }
    }
}