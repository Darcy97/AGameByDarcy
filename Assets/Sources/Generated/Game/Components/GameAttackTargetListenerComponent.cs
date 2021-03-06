//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AttackTargetListenerComponent attackTargetListener { get { return (AttackTargetListenerComponent)GetComponent(GameComponentsLookup.AttackTargetListener); } }
    public bool hasAttackTargetListener { get { return HasComponent(GameComponentsLookup.AttackTargetListener); } }

    public void AddAttackTargetListener(System.Collections.Generic.List<IAttackTargetListener> newValue) {
        var index = GameComponentsLookup.AttackTargetListener;
        var component = CreateComponent<AttackTargetListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAttackTargetListener(System.Collections.Generic.List<IAttackTargetListener> newValue) {
        var index = GameComponentsLookup.AttackTargetListener;
        var component = CreateComponent<AttackTargetListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAttackTargetListener() {
        RemoveComponent(GameComponentsLookup.AttackTargetListener);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAttackTargetListener;

    public static Entitas.IMatcher<GameEntity> AttackTargetListener {
        get {
            if (_matcherAttackTargetListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackTargetListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackTargetListener = matcher;
            }

            return _matcherAttackTargetListener;
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
public partial class GameEntity {

    public void AddAttackTargetListener(IAttackTargetListener value) {
        var listeners = hasAttackTargetListener
            ? attackTargetListener.value
            : new System.Collections.Generic.List<IAttackTargetListener>();
        listeners.Add(value);
        ReplaceAttackTargetListener(listeners);
    }

    public void RemoveAttackTargetListener(IAttackTargetListener value, bool removeComponentWhenEmpty = true) {
        var listeners = attackTargetListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAttackTargetListener();
        } else {
            ReplaceAttackTargetListener(listeners);
        }
    }
}
