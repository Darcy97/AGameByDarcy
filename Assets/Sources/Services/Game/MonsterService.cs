using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class MonsterService
{
    private GameController _gameController;
    private Contexts _contexts;

    public static MonsterService singlton = new MonsterService();

    public void Initialize(Contexts contexts, GameController controller)
    {
        _contexts = contexts;
        _gameController = controller;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="transform" 被控制角色></param>
    /// <param name="target" 目标角色></param>
    public void RunToEnemy(Transform transform, RoleType target)
    {
        Transform _target;
        if (target == RoleType.MainRole)
            _target = _gameController.MainRole;
        else
            _target = null;

        if (_target == null)
            return;

        ThirdPersonCharacter character = transform.GetComponent<ThirdPersonCharacter>();
        Vector3 direction = (_target.position - transform.position).normalized;

        character.Move(direction, false, false);
    }

}

