using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class GameSceneSystem : /*ReactiveSystem<GameEntity>,*/ IInitializeSystem {

    const int m_monster_number = 100;

    public EntityService entityService = EntityService.singleton;
    public RandomService randomService = RandomService.gameScene;

    public GameSceneSystem(Contexts contexts) //: base(contexts.game)
    {
        
    }


    public void Initialize()
    {
        
        //TODO init all monsters
        for (int i = 0; i < m_monster_number; i++)
        {
            
            float x = randomService.Float(-80, 80);
            float y = 2; 
            float z = randomService.Float(-80, 80);
            
            entityService.CreateRandomMonster(x, y, z, i);
        }
    }

    /*
    
    protected override void Execute(List<GameEntity> entities)
    {
        //TODO
        Debug.Log("d");
        return;
    }

    protected override bool Filter(GameEntity entity)
    {
        //TODO
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        //TODO
        //return context.CreateCollector(GameMatcher.)
        return null;
    }
    */
    
}

