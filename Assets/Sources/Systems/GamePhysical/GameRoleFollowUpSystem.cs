using System.Collections.Generic;
using Entitas;
using UnityEngine;

class GameRoleFollowUpSystem : ReactiveSystem<GameEntity>
{
    private MonsterService _monsterService = MonsterService.singlton;

    private Transform _role;

    public GameRoleFollowUpSystem(IContext<GameEntity> context) : base(context)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var item in entities)
        {
            Debug.Log("away");
            

            //_monsterService.RunToEnemy(item.monsterController.value, item.catchRole.value);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
            //entity.isMovable;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector<GameEntity>(GameMatcher.CatchRole.Removed());
       
    }
}

