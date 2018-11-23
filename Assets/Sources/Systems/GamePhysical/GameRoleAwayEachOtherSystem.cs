using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class GameRoleAwayEachOtherSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{

    public GameRoleAwayEachOtherSystem(IContext<GameEntity> context) : base(context)
    {

    }

    public void Initialize()
    {
        //TODO 读取配置表
    }


    /// <summary>
    /// 对应表
    /// CanBeFollowUpArea : mainRole
    /// 
    /// 
    /// 
    /// </summary>
    /// <param name="entities"></param>
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {

            if (e.awayRole.value == "CanEscapeArea")
            {
                if (e.hasFollowTarget)
                {
                    
                    e.ReplaceFollowTarget(RoleType.Default);
                }
                else
                {
                    
                }

            }
            else if (e.catchRole.value == "CanEscapeArea")
            {

            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasFollowTarget;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AwayRole);
    }
}
