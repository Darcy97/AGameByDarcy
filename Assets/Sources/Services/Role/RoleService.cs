﻿using UnityEngine;

public class RoleService : IAssetListener
{
    public static RoleService singlton = new RoleService();

    Contexts _contexts;
    Transform _parent;

    public void Initialize(Contexts contexts, Transform parent)
    {
        _contexts = contexts;
        _parent = parent;

        var e = contexts.game.CreateEntity();
        e.AddAssetListener(this);
    }


    public void OnAsset(GameEntity entity, string value)
    {
        var prefab = Resources.Load<GameObject>(value);
        GameObject obj = Object.Instantiate(prefab, _parent);
        obj.transform.rotation = Quaternion.identity;
        var role = obj.GetComponent<IRole>();
        role.Link(entity, _contexts.game);
        
    }
  
}
