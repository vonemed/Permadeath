//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameUIShowEventSystem : Entitas.ReactiveSystem<GameUIEntity> {

    readonly System.Collections.Generic.List<IGameUIShowListener> _listenerBuffer;

    public GameUIShowEventSystem(Contexts contexts) : base(contexts.gameUI) {
        _listenerBuffer = new System.Collections.Generic.List<IGameUIShowListener>();
    }

    protected override Entitas.ICollector<GameUIEntity> GetTrigger(Entitas.IContext<GameUIEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameUIMatcher.Show)
        );
    }

    protected override bool Filter(GameUIEntity entity) {
        return entity.isShow && entity.hasGameUIShowListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameUIEntity> entities) {
        foreach (var e in entities) {
            
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.gameUIShowListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnShow(e);
            }
        }
    }
}
