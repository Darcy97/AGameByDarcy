using System;

public class Services
{
    public static Services singlton = new Services();

    public void Initialize(Contexts contexts, GameController gameController)
    {
        var random = new Random(DateTime.UtcNow.Millisecond);
        UnityEngine.Random.InitState(random.Next());
        RandomService.gameLogic.Initialize(random.Next());
        RandomService.gameScene.Initialize(random.Next());
        EntityService.singleton.Initialize(contexts);

        RoleService.singlton.Initialize(contexts, gameController.transform);
        MonsterService.singlton.Initialize(contexts, gameController);
        //MonsterInstantiateService.singleton.Initialize(contexts, gameController.transform);
    }
}

