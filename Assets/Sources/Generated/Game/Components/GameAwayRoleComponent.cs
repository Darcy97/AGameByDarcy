//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AwayRoleComponent awayRole { get { return (AwayRoleComponent)GetComponent(GameComponentsLookup.AwayRole); } }
    public bool hasAwayRole { get { return HasComponent(GameComponentsLookup.AwayRole); } }

    public void AddAwayRole(string newValue) {
        var index = GameComponentsLookup.AwayRole;
        var component = CreateComponent<AwayRoleComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAwayRole(string newValue) {
        var index = GameComponentsLookup.AwayRole;
        var component = CreateComponent<AwayRoleComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAwayRole() {
        RemoveComponent(GameComponentsLookup.AwayRole);
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

    static Entitas.IMatcher<GameEntity> _matcherAwayRole;

    public static Entitas.IMatcher<GameEntity> AwayRole {
        get {
            if (_matcherAwayRole == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AwayRole);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAwayRole = matcher;
            }

            return _matcherAwayRole;
        }
    }
}
