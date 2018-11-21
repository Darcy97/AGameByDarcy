using Entitas;
using UnityEngine;


public class EntityService {

    public static EntityService singleton = new EntityService();


    private Contexts _contexts;

    public void Initialize(Contexts contexts)
    {
        _contexts = contexts;
    }


    public GameEntity CreateRandomMonster(float x, float y, float z)
    {
        Debug.Log("createrandommonster");
        var entity = _contexts.game.CreateEntity();
        entity.AddGameMonster(0);
        entity.AddPosition(new FloatVector3(x, y, z));
        entity.AddAsset("Prefabs/Mon.prefab");
        
        entity.isMovable = true;
        return entity;
    }


}

