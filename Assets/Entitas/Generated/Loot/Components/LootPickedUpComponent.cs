//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LootEntity {

    static readonly Loot.PickedUpComponent pickedUpComponent = new Loot.PickedUpComponent();

    public bool isPickedUp {
        get { return HasComponent(LootComponentsLookup.PickedUp); }
        set {
            if (value != isPickedUp) {
                var index = LootComponentsLookup.PickedUp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : pickedUpComponent;

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
public sealed partial class LootMatcher {

    static Entitas.IMatcher<LootEntity> _matcherPickedUp;

    public static Entitas.IMatcher<LootEntity> PickedUp {
        get {
            if (_matcherPickedUp == null) {
                var matcher = (Entitas.Matcher<LootEntity>)Entitas.Matcher<LootEntity>.AllOf(LootComponentsLookup.PickedUp);
                matcher.componentNames = LootComponentsLookup.componentNames;
                _matcherPickedUp = matcher;
            }

            return _matcherPickedUp;
        }
    }
}