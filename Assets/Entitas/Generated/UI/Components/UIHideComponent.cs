//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UIEntity {

    static readonly Game.HideComponent hideComponent = new Game.HideComponent();

    public bool isHide {
        get { return HasComponent(UIComponentsLookup.Hide); }
        set {
            if (value != isHide) {
                var index = UIComponentsLookup.Hide;
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
public partial class UIEntity : IHideEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UIMatcher {

    static Entitas.IMatcher<UIEntity> _matcherHide;

    public static Entitas.IMatcher<UIEntity> Hide {
        get {
            if (_matcherHide == null) {
                var matcher = (Entitas.Matcher<UIEntity>)Entitas.Matcher<UIEntity>.AllOf(UIComponentsLookup.Hide);
                matcher.componentNames = UIComponentsLookup.componentNames;
                _matcherHide = matcher;
            }

            return _matcherHide;
        }
    }
}
