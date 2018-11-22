using Entitas;
using UnityEngine;

public class GamePhysicalController : MonoBehaviour
{
    private Systems _systems;

    public Terrain SmallTerrain;
    public Terrain BigTerrain;

    public Transform MainRole;

    private void Awake()
    {

        var contexts = Contexts.sharedInstance;

        _systems = new GamePhysicalSystems(contexts);

    }


    void Start()
    {
        _systems.Initialize();

    }

    private void OnDestroy()
    {
        _systems.TearDown();
    }


    private void FixedUpdate()
    {
        _systems.Execute();
    }


}

