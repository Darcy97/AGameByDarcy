using UnityEngine;
using Entitas;
using System.Linq;

public class Monster : Role, ICatchRoleListener, IAttackTargetListener
{
    private int _index;

    public override void Link(IEntity entity, IContext context)
    {
        base.Link(entity, context);

        GameEntity e = (GameEntity)entity;

        _index = e.gameMonster.value;
        e.AddAttackTargetListener(this);
    }

    private RoleType _target = RoleType.Default;

    public void OnAttackTarget(GameEntity entity, RoleType value)
    {
        _target = value;
    }

    private bool _canFollowUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanBeFollowUpArea"))
        {
            var monsters = Contexts.sharedInstance.game.GetEntitiesWithGameMonster(_index).Where(e => e.isMovable)
                    .ToArray();
            if(monsters != null)
            {
                monsters[0].AddCatchRole(RoleType.MainRole);
            }
            //_canFollowUp = true; //进入追击范围
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CanEscapeArea"))
            _canFollowUp = false;
    }

    private void FixedUpdate()
    {
        if (base.canMove && _target != RoleType.Default && _canFollowUp)
            MonsterService.singlton.RunToEnemy(transform, RoleType.MainRole);
    }

    public void OnCatchRole(GameEntity entity, RoleType value)
    {
        
    }

    private bool _randomMove;
    private void Start()
    {
        //random move
        _randomMove = true;
    }

}
