//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class ObjectPoolerResetEventSystem : Entitas.ReactiveSystem<ObjectPoolerEntity> {

    readonly System.Collections.Generic.List<IObjectPoolerResetListener> _listenerBuffer;

    public ObjectPoolerResetEventSystem(Contexts contexts) : base(contexts.objectPooler) {
        _listenerBuffer = new System.Collections.Generic.List<IObjectPoolerResetListener>();
    }

    protected override Entitas.ICollector<ObjectPoolerEntity> GetTrigger(Entitas.IContext<ObjectPoolerEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(ObjectPoolerMatcher.Reset)
        );
    }

    protected override bool Filter(ObjectPoolerEntity entity) {
        return entity.isReset && entity.hasObjectPoolerResetListener;
    }

    protected override void Execute(System.Collections.Generic.List<ObjectPoolerEntity> entities) {
        foreach (var e in entities) {
            
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.objectPoolerResetListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnReset(e);
            }
        }
    }
}