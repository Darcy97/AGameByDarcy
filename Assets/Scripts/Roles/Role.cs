using Entitas;
using Entitas.Unity;
using UnityEngine;

public class Role : MonoBehaviour, IRole, IDestroyedListener, IPositionListener, IMovableListener
{


    public virtual void Link(IEntity entity, IContext context)
    {
        gameObject.Link(entity, context);
        var e = (GameEntity)entity;
        e.AddPositionListener(this);
        e.AddDestroyedListener(this);

        var pos = e.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
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
}

