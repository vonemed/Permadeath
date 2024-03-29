//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemyEntity {

    static readonly Game.PausedComponent pausedComponent = new Game.PausedComponent();

    public bool isPaused {
        get { return HasComponent(EnemyComponentsLookup.Paused); }
        set {
            if (value != isPaused) {
                var index = EnemyComponentsLookup.Paused;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : pausedComponent;

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
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemyEntity : IPausedEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class EnemyMatcher {

    static Entitas.IMatcher<EnemyEntity> _matcherPaused;

    public static Entitas.IMatcher<EnemyEntity> Paused {
        get {
            if (_matcherPaused == null) {
                var matcher = (Entitas.Matcher<EnemyEntity>)Entitas.Matcher<EnemyEntity>.AllOf(EnemyComponentsLookup.Paused);
                matcher.componentNames = EnemyComponentsLookup.componentNames;
                _matcherPaused = matcher;
            }

            return _matcherPaused;
        }
    }
}
