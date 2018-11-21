
public sealed class GameSystems : Feature {

    public GameSystems(Contexts contexts)
    {

        
        Add(new GameSceneSystem(contexts));


    }
	
}

