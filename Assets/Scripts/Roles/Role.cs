using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Role : MonoBehaviour, IRole, IDestroyedListener, IPositionListener, IMovableListener, IAttackTargetListener
{

    public virtual void Link(IEntity entity, IContext context)
    {
        gameObject.Link(entity, context);
        var e = (GameEntity)entity;
        e.AddPositionListener(this);
        e.AddDestroyedListener(this);
        e.AddMovableListener(this);
        e.AddAttackTargetListener(this);

        var pos = e.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
    }

    private bool _randomMove;
    private void Start()
    {
        //random move
        _randomMove = true;
    }

    public void OnDestroyed(GameEntity entity)
    {
        destroy();
    }

    protected virtual void destroy()
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }

    public void OnPosition(GameEntity entity, FloatVector3 value)
    {
        transform.localPosition = new Vector3(value.x, value.y, value.z);
    }

    private bool canMove;
    public void OnMovable(GameEntity entity)
    {
        canMove = entity.isMovable; 
    }

    private RoleType _target = RoleType.Default;

    public void OnAttackTarget(GameEntity entity, RoleType value)
    {
        _target = value;
    }

    private bool _canFollowUp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CanBeFollowUpArea"))
            _canFollowUp = true; //进入追击范围
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CanEscapeArea"))
            _canFollowUp = false;
    }

    private void FixedUpdate()
    {
        if(canMove && _target != RoleType.Default && _canFollowUp)
            MonsterService.singlton.RunToEnemy(transform, RoleType.MainRole);
    }
}

