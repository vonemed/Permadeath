//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ObjectPoolerEntity {

    public Pools.CurrentWaveComponent currentWave { get { return (Pools.CurrentWaveComponent)GetComponent(ObjectPoolerComponentsLookup.CurrentWave); } }
    public bool hasCurrentWave { get { return HasComponent(ObjectPoolerComponentsLookup.CurrentWave); } }

    public void AddCurrentWave(int newValue) {
        var index = ObjectPoolerComponentsLookup.CurrentWave;
        var component = (Pools.CurrentWaveComponent)CreateComponent(index, typeof(Pools.CurrentWaveComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurrentWave(int newValue) {
        var index = ObjectPoolerComponentsLookup.CurrentWave;
        var component = (Pools.CurrentWaveComponent)CreateComponent(index, typeof(Pools.CurrentWaveComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentWave() {
        RemoveComponent(ObjectPoolerComponentsLookup.CurrentWave);
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
public sealed partial class ObjectPoolerMatcher {

    static Entitas.IMatcher<ObjectPoolerEntity> _matcherCurrentWave;

    public static Entitas.IMatcher<ObjectPoolerEntity> CurrentWave {
        get {
            if (_matcherCurrentWave == null) {
                var matcher = (Entitas.Matcher<ObjectPoolerEntity>)Entitas.Matcher<ObjectPoolerEntity>.AllOf(ObjectPoolerComponentsLookup.CurrentWave);
                matcher.componentNames = ObjectPoolerComponentsLookup.componentNames;
                _matcherCurrentWave = matcher;
            }

            return _matcherCurrentWave;
        }
    }
}