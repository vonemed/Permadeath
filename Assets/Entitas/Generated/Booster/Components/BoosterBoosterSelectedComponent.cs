//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BoosterEntity {

    public Boosters.BoosterSelectedComponent boosterSelected { get { return (Boosters.BoosterSelectedComponent)GetComponent(BoosterComponentsLookup.BoosterSelected); } }
    public bool hasBoosterSelected { get { return HasComponent(BoosterComponentsLookup.BoosterSelected); } }

    public void AddBoosterSelected(Boosters.BoosterStats newBoosterStats) {
        var index = BoosterComponentsLookup.BoosterSelected;
        var component = (Boosters.BoosterSelectedComponent)CreateComponent(index, typeof(Boosters.BoosterSelectedComponent));
        component.boosterStats = newBoosterStats;
        AddComponent(index, component);
    }

    public void ReplaceBoosterSelected(Boosters.BoosterStats newBoosterStats) {
        var index = BoosterComponentsLookup.BoosterSelected;
        var component = (Boosters.BoosterSelectedComponent)CreateComponent(index, typeof(Boosters.BoosterSelectedComponent));
        component.boosterStats = newBoosterStats;
        ReplaceComponent(index, component);
    }

    public void RemoveBoosterSelected() {
        RemoveComponent(BoosterComponentsLookup.BoosterSelected);
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
public sealed partial class BoosterMatcher {

    static Entitas.IMatcher<BoosterEntity> _matcherBoosterSelected;

    public static Entitas.IMatcher<BoosterEntity> BoosterSelected {
        get {
            if (_matcherBoosterSelected == null) {
                var matcher = (Entitas.Matcher<BoosterEntity>)Entitas.Matcher<BoosterEntity>.AllOf(BoosterComponentsLookup.BoosterSelected);
                matcher.componentNames = BoosterComponentsLookup.componentNames;
                _matcherBoosterSelected = matcher;
            }

            return _matcherBoosterSelected;
        }
    }
}
