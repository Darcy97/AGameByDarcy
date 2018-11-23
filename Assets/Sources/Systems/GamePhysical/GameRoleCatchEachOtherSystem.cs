using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class GameRoleCatchEachOtherSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{ 

    public GameRoleCatchEachOtherSystem(IContext<GameEntity> context) : base(context)
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
            
            if (e.catchRole.value == "CanBeFollowUpArea")
            {
                if (!e.hasFollowTarget || e.followTarget.value == RoleType.Default)
                {
                    e.ReplaceFollowTarget(RoleType.MainRole);
                }
                else
                {
                    //多个目标可追踪时处理追踪优先级
                }
                
            }
            else if(e.catchRole.value == "CanEscapeArea")
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

