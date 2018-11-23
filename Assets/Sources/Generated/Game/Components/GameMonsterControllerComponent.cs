//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MonsterController monsterController { get { return (MonsterController)GetComponent(GameComponentsLookup.MonsterController); } }
    public bool hasMonsterController { get { return HasComponent(GameComponentsLookup.MonsterController); } }

    public void AddMonsterController(UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter newValue) {
        var index = GameComponentsLookup.MonsterController;
        var component = CreateComponent<MonsterController>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMonsterController(UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter newValue) {
        var index = GameComponentsLookup.MonsterController;
        var component = CreateComponent<MonsterController>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMonsterController() {
        RemoveComponent(GameComponentsLookup.MonsterController);
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

    static Entitas.IMatcher<GameEntity> _matcherMonsterController;

    public static Entitas.IMatcher<GameEntity> MonsterController {
        get {
            if (_matcherMonsterController == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MonsterController);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMonsterController = matcher;
            }

            return _matcherMonsterController;
        }
    }
}