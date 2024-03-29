//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemyEntity {

    public EnemyAnyLevelListenerComponent enemyAnyLevelListener { get { return (EnemyAnyLevelListenerComponent)GetComponent(EnemyComponentsLookup.EnemyAnyLevelListener); } }
    public bool hasEnemyAnyLevelListener { get { return HasComponent(EnemyComponentsLookup.EnemyAnyLevelListener); } }

    public void AddEnemyAnyLevelListener(System.Collections.Generic.List<IEnemyAnyLevelListener> newValue) {
        var index = EnemyComponentsLookup.EnemyAnyLevelListener;
        var component = (EnemyAnyLevelListenerComponent)CreateComponent(index, typeof(EnemyAnyLevelListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEnemyAnyLevelListener(System.Collections.Generic.List<IEnemyAnyLevelListener> newValue) {
        var index = EnemyComponentsLookup.EnemyAnyLevelListener;
        var component = (EnemyAnyLevelListenerComponent)CreateComponent(index, typeof(EnemyAnyLevelListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEnemyAnyLevelListener() {
        RemoveComponent(EnemyComponentsLookup.EnemyAnyLevelListener);
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
public sealed partial class EnemyMatcher {

    static Entitas.IMatcher<EnemyEntity> _matcherEnemyAnyLevelListener;

    public static Entitas.IMatcher<EnemyEntity> EnemyAnyLevelListener {
        get {
            if (_matcherEnemyAnyLevelListener == null) {
                var matcher = (Entitas.Matcher<EnemyEntity>)Entitas.Matcher<EnemyEntity>.AllOf(EnemyComponentsLookup.EnemyAnyLevelListener);
                matcher.componentNames = EnemyComponentsLookup.componentNames;
                _matcherEnemyAnyLevelListener = matcher;
            }

            return _matcherEnemyAnyLevelListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemyEntity {

    public void AddEnemyAnyLevelListener(IEnemyAnyLevelListener value) {
        var listeners = hasEnemyAnyLevelListener
            ? enemyAnyLevelListener.value
            : new System.Collections.Generic.List<IEnemyAnyLevelListener>();
        listeners.Add(value);
        ReplaceEnemyAnyLevelListener(listeners);
    }

    public void RemoveEnemyAnyLevelListener(IEnemyAnyLevelListener value, bool removeComponentWhenEmpty = true) {
        var listeners = enemyAnyLevelListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveEnemyAnyLevelListener();
        } else {
            ReplaceEnemyAnyLevelListener(listeners);
        }
    }
}
