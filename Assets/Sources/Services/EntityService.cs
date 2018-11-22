using Entitas;
using UnityEngine;


public class EntityService {

    public static EntityService singleton = new EntityService();

    const string m_monster_prefab = "Prefabs/MonRight";

    private Contexts _contexts;

    public void Initialize(Contexts contexts)
    {
        _contexts = contexts;
    }


    public GameEntity CreateRandomMonster(float x, float y, float z, int index)
    {
        Debug.Log("createrandommonster");
        var entity = _contexts.game.CreateEntity();
        
        //entity.AddGameMonster(0);
        entity.AddPosition(new FloatVector3(x, y, z));
        entity.AddGameMonster(index);
        entity.AddAsset(m_monster_prefab);
        entity.isMovable = true;

        return entity;
    }


}

