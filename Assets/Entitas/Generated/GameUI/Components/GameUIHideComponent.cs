//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameUIEntity {

    static readonly Game.HideComponent hideComponent = new Game.HideComponent();

    public bool isHide {
        get { return HasComponent(GameUIComponentsLookup.Hide); }
        set {
            if (value != isHide) {
                var index = GameUIComponentsLookup.Hide;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : hideComponent;

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
public partial class GameUIEntity : IHideEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameUIMatcher {

    static Entitas.IMatcher<GameUIEntity> _matcherHide;

    public static Entitas.IMatcher<GameUIEntity> Hide {
        get {
            if (_matcherHide == null) {
                var matcher = (Entitas.Matcher<GameUIEntity>)Entitas.Matcher<GameUIEntity>.AllOf(GameUIComponentsLookup.Hide);
                matcher.componentNames = GameUIComponentsLookup.componentNames;
                _matcherHide = matcher;
            }

            return _matcherHide;
        }
    }
}
