using Entitas;
using UnityEngine;


public class EntityService {

    public static EntityService singleton = new EntityService();

    const string m_monster_prefab = "Prefabs/Mon";

    private Contexts _contexts;

    public void Initialize(Contexts contexts)
    {
        _contexts = contexts;
    }


    public GameEntity CreateRandomMonster(float x, float y, float z)
    {
        Debug.Log("createrandommonster");
        var entity = _contexts.game.CreateEntity();
        
        //entity.AddGameMonster(0);
        entity.AddPosition(new FloatVector3(x, y, z));
        Debug.Log(entity.position.value.x);
        entity.AddAsset(m_monster_prefab);
        
        entity.isMovable = true;
        return entity;
    }


}

