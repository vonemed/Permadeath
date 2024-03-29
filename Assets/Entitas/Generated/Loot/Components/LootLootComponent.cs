//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LootEntity {

    static readonly Loot.LootComponent lootComponent = new Loot.LootComponent();

    public bool isLoot {
        get { return HasComponent(LootComponentsLookup.Loot); }
        set {
            if (value != isLoot) {
                var index = LootComponentsLookup.Loot;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : lootComponent;

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

    static Entitas.IMatcher<LootEntity> _matcherLoot;

    public static Entitas.IMatcher<LootEntity> Loot {
        get {
            if (_matcherLoot == null) {
                var matcher = (Entitas.Matcher<LootEntity>)Entitas.Matcher<LootEntity>.AllOf(LootComponentsLookup.Loot);
                matcher.componentNames = LootComponentsLookup.componentNames;
                _matcherLoot = matcher;
            }

            return _matcherLoot;
        }
    }
}
