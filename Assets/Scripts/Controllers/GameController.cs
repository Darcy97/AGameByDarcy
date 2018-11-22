using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    private Systems _systems;

    public Services services = Services.singlton;

    public Terrain SmallTerrain;
    public Terrain BigTerrain;

    public Transform MonsterTarget;
    
    private void Awake()
    {
        
        var contexts = Contexts.sharedInstance;

        services.Initialize(contexts, this);
        
        _systems = new GameSystems(contexts);
        
    }
    

    void Start () {
        _systems.Initialize();
        
	}
	
	
	void Update () {
        _systems.Execute();
        _systems.Cleanup();
	}

    private void OnDestroy()
    {
        _systems.TearDown();
    }
}
