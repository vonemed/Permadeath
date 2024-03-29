//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BoosterEntity {

    static readonly Boosters.BoosterTypeComponent boosterTypeComponent = new Boosters.BoosterTypeComponent();

    public bool isBoosterType {
        get { return HasComponent(BoosterComponentsLookup.BoosterType); }
        set {
            if (value != isBoosterType) {
                var index = BoosterComponentsLookup.BoosterType;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : boosterTypeComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<BoosterEntity> _matcherBoosterType;

    public static Entitas.IMatcher<BoosterEntity> BoosterType {
        get {
            if (_matcherBoosterType == null) {
                var matcher = (Entitas.Matcher<BoosterEntity>)Entitas.Matcher<BoosterEntity>.AllOf(BoosterComponentsLookup.BoosterType);
                matcher.componentNames = BoosterComponentsLookup.componentNames;
                _matcherBoosterType = matcher;
            }

            return _matcherBoosterType;
        }
    }
}
