//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class EnemyAnyLevelEventSystem : Entitas.ReactiveSystem<EnemyEntity> {

    readonly Entitas.IGroup<EnemyEntity> _listeners;
    readonly System.Collections.Generic.List<EnemyEntity> _entityBuffer;
    readonly System.Collections.Generic.List<IEnemyAnyLevelListener> _listenerBuffer;

    public EnemyAnyLevelEventSystem(Contexts contexts) : base(contexts.enemy) {
        _listeners = contexts.enemy.GetGroup(EnemyMatcher.EnemyAnyLevelListener);
        _entityBuffer = new System.Collections.Generic.List<EnemyEntity>();
        _listenerBuffer = new System.Collections.Generic.List<IEnemyAnyLevelListener>();
    }

    protected override Entitas.ICollector<EnemyEntity> GetTrigger(Entitas.IContext<EnemyEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(EnemyMatcher.Level)
        );
    }

    protected override bool Filter(EnemyEntity entity) {
        return entity.hasLevel;
    }

    protected override void Execute(System.Collections.Generic.List<EnemyEntity> entities) {
        foreach (var e in entities) {
            var component = e.level;
            foreach (var listenerEntity in _listeners.GetEntities(_entityBuffer)) {
                _listenerBuffer.Clear();
                _listenerBuffer.AddRange(listenerEntity.enemyAnyLevelListener.value);
                foreach (var listener in _listenerBuffer) {
                    listener.OnAnyLevel(e, component.value);
                }
            }
        }
    }
}
