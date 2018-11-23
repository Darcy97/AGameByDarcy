using UnityEngine;
using Entitas;
using System.Linq;

public class Monster : Role, IAttackTargetListener, IFollowTargetListener
{
    public int _index;

    public override void Link(IEntity entity, IContext context)
    {
        base.Link(entity, context);
        
        GameEntity e = (GameEntity)entity;

        _index = e.gameMonster.value;
        e.AddAttackTargetListener(this);
        e.AddFollowTargetListener(this);
    }

    private RoleType _target = RoleType.Default;

    public void OnAttackTarget(GameEntity entity, RoleType value)
    {
        _target = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        var monsters = Contexts
            .sharedInstance
            .game
            .GetEntitiesWithGameMonster(_index)
            .Where(e => e.isMovable)
            .ToArray();

        if (monsters.Length > 0)
        {
            monsters[0].ReplaceCatchRole(other.tag);        
        }  
    }

    private void OnTriggerExit(Collider other)
    { 
         var monsters = Contexts
             .sharedInstance
             .game
             .GetEntitiesWithGameMonster(_index)
             .Where(e => e.hasFollowTarget)
             .ToArray();

        if (monsters.Length > 0)
         {            
            monsters[0].ReplaceAwayRole(other.tag);
         }
    }

    private void FixedUpdate()
    {
        if (_catchRole)
            MonsterService.singlton.RunToEnemy(transform, _followTarget);
    }

    private bool _randomMove;
    private void Start()
    {
        // random move
        _randomMove = true;
    }

    private bool _catchRole;
    private RoleType _followTarget;

    public void OnFollowTarget(GameEntity entity, RoleType value)
    {
        if (value == RoleType.MainRole)
        {
            _catchRole = true;
            _followTarget = value;
        }
        else if(value == RoleType.Default)
        {
            _catchRole = false;
            MonsterService.singlton.Stop(transform);
        }
    }
}
