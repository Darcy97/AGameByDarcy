using UnityEngine;

class RoleService : IAssetListener
{
    public static RoleService singlton = new RoleService();

    Contexts _contexts;
    Transform _parent;

    public void Initialize(Contexts contexts, Transform parent)
    {
        _contexts = contexts;
        _parent = parent;
        contexts.game.CreateEntity().AddAssetListener(this);
    }

    public void OnAsset(GameEntity entity, string value)
    {
        Debug.Log("onasset");
        var prefab = Resources.Load<GameObject>(value);
        var role = Object.Instantiate(prefab, _parent).GetComponent<IRole>();
        role.Link(entity, _contexts.game);
    }
}
