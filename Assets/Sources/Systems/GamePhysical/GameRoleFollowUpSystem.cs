using System.Collections.Generic;
using Entitas;

class GameRoleFollowUpSystem : ReactiveSystem<GameEntity>
{
    public GameRoleFollowUpSystem(IContext<GameEntity> context) : base(context)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var item in entities)
        {
            if(item.isMoving)
            {

            }


        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMovable;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CatchRole);
    }
}

