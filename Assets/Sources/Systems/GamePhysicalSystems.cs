

class GamePhysicalSystems:Feature
{
    public GamePhysicalSystems(Contexts contexts)
    {

        Add(new GameRoleFollowUpSystem(contexts.game));
 
    }
}

