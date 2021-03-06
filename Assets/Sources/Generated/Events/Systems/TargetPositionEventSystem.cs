//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class TargetPositionEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<ITargetPositionListener> _listenerBuffer;

    public TargetPositionEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<ITargetPositionListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.TargetPosition)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasTargetPosition && entity.hasTargetPositionListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.targetPosition;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.targetPositionListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnTargetPosition(e, component.value);
            }
        }
    }
}
