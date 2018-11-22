using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Role : 
    MonoBehaviour, 
    IRole, 
    IDestroyedListener, 
    IPositionListener, 
    IMovableListener, 
    ITargetPositionListener
{

    public virtual void Link(IEntity entity, IContext context)
    {
        gameObject.Link(entity, context);
        var e = (GameEntity)entity;
        e.AddPositionListener(this);
        e.AddDestroyedListener(this);
        e.AddMovableListener(this);
        e.AddTargetPositionListener(this);
        

        var pos = e.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
    }

    private void Start()
    {
        
    }

    public bool mo;
    public bool sto;

    private void FixedUpdate()
    {
        if (mo)
        {
            mo = false;
            GetComponent<ThirdPersonCharacter>().Move(new Vector3(10, 2, 10), false, false);
        }

        if (sto) 
        {
            sto = false;
            GetComponent<ThirdPersonCharacter>().Move(new Vector3(0.1f, 0, 0.1f), false, false);
        }
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

    protected bool canMove;
    public void OnMovable(GameEntity entity)
    {
        canMove = entity.isMovable; 
    }

    public void OnTargetPosition(GameEntity entity, FloatVector3 value)
    {
        MonsterService.singlton.RunToEnemy(transform, RoleType.MainRole);
        entity.isMoving = true;
    }


}

