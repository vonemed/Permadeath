//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UIContext {

    public UIEntity boosterChoosePanelEntity { get { return GetGroup(UIMatcher.BoosterChoosePanel).GetSingleEntity(); } }

    public bool isBoosterChoosePanel {
        get { return boosterChoosePanelEntity != null; }
        set {
            var entity = boosterChoosePanelEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isBoosterChoosePanel = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UIEntity {

    static readonly UI.BoosterChoosePanelComponent boosterChoosePanelComponent = new UI.BoosterChoosePanelComponent();

    public bool isBoosterChoosePanel {
        get { return HasComponent(UIComponentsLookup.BoosterChoosePanel); }
        set {
            if (value != isBoosterChoosePanel) {
                var index = UIComponentsLookup.BoosterChoosePanel;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : boosterChoosePanelComponent;

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
public sealed partial class UIMatcher {

    static Entitas.IMatcher<UIEntity> _matcherBoosterChoosePanel;

    public static Entitas.IMatcher<UIEntity> BoosterChoosePanel {
        get {
            if (_matcherBoosterChoosePanel == null) {
                var matcher = (Entitas.Matcher<UIEntity>)Entitas.Matcher<UIEntity>.AllOf(UIComponentsLookup.BoosterChoosePanel);
                matcher.componentNames = UIComponentsLookup.componentNames;
                _matcherBoosterChoosePanel = matcher;
            }

            return _matcherBoosterChoosePanel;
        }
    }
}
