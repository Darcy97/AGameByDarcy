//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FollowTargetComponent followTarget { get { return (FollowTargetComponent)GetComponent(GameComponentsLookup.FollowTarget); } }
    public bool hasFollowTarget { get { return HasComponent(GameComponentsLookup.FollowTarget); } }

    public void AddFollowTarget(RoleType newValue) {
        var index = GameComponentsLookup.FollowTarget;
        var component = CreateComponent<FollowTargetComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFollowTarget(RoleType newValue) {
        var index = GameComponentsLookup.FollowTarget;
        var component = CreateComponent<FollowTargetComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFollowTarget() {
        RemoveComponent(GameComponentsLookup.FollowTarget);
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

    static Entitas.IMatcher<GameEntity> _matcherFollowTarget;

    public static Entitas.IMatcher<GameEntity> FollowTarget {
        get {
            if (_matcherFollowTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FollowTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFollowTarget = matcher;
            }

            return _matcherFollowTarget;
        }
    }
}
