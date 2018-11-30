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

    public void OnPosition(GameEntity entity, UnityEngine.Vector3 value)
    {
        transform.localPosition = new Vector3(value.x, value.y, value.z);
    }

    protected bool canMove;
    public void OnMovable(GameEntity entity)
    {
        canMove = entity.isMovable; 
    }

    protected bool _hasTargetPosition;
    protected Vector3 _targetPosition;
    public void OnTargetPosition(GameEntity entity, UnityEngine.Vector3 value)
    {
        _hasTargetPosition = true;
        _targetPosition = value;       
    }




}

