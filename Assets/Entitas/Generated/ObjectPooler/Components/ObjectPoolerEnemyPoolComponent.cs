//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ObjectPoolerContext {

    public ObjectPoolerEntity enemyPoolEntity { get { return GetGroup(ObjectPoolerMatcher.EnemyPool).GetSingleEntity(); } }

    public bool isEnemyPool {
        get { return enemyPoolEntity != null; }
        set {
            var entity = enemyPoolEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isEnemyPool = true;
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
public partial class ObjectPoolerEntity {

    static readonly Pools.EnemyPoolComponent enemyPoolComponent = new Pools.EnemyPoolComponent();

    public bool isEnemyPool {
        get { return HasComponent(ObjectPoolerComponentsLookup.EnemyPool); }
        set {
            if (value != isEnemyPool) {
                var index = ObjectPoolerComponentsLookup.EnemyPool;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : enemyPoolComponent;

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
public sealed partial class ObjectPoolerMatcher {

    static Entitas.IMatcher<ObjectPoolerEntity> _matcherEnemyPool;

    public static Entitas.IMatcher<ObjectPoolerEntity> EnemyPool {
        get {
            if (_matcherEnemyPool == null) {
                var matcher = (Entitas.Matcher<ObjectPoolerEntity>)Entitas.Matcher<ObjectPoolerEntity>.AllOf(ObjectPoolerComponentsLookup.EnemyPool);
                matcher.componentNames = ObjectPoolerComponentsLookup.componentNames;
                _matcherEnemyPool = matcher;
            }

            return _matcherEnemyPool;
        }
    }
}