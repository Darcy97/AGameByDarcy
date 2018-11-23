using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

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
        entity.AddMonsterController(obj.GetComponent<ThirdPersonCharacter>());
        obj.transform.rotation = Quaternion.identity;
        var role = obj.GetComponent<Monster>();
        role.Link(entity, _contexts.game);

        entity.AddTargetPosition(GetARandomPositionWithPosition(entity.position.value));

    }

    private Vector3 GetARandomPositionWithPosition(Vector3 position)
    {
        return position + new Vector3(RandomService.gameScene.Float(-200, 200), 0, RandomService.gameScene.Float(-5, 5));
    }

}
