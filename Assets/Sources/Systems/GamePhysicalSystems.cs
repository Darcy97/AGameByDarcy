

class GamePhysicalSystems:Feature
{
    public GamePhysicalSystems(Contexts contexts)
    {

       // Add(new GameRoleFollowUpSystem(contexts.game));
        Add(new GameRoleCatchEachOtherSystem(contexts.game));
        Add(new GameRoleAwayEachOtherSystem(contexts.game));

    }
}

