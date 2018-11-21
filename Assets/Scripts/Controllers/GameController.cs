using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    private Systems _systems;

    public Services services = Services.singlton;

    public Terrain SmallTerrain;
    public Terrain BigTerrain;
    
    private void Awake()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new GameSystems(contexts);
        services.Initialize(contexts, this);
    }
    

    void Start () {
        _systems.Initialize();
        
	}
	
	
	void Update () {
        //_systems.Execute();
        //_systems.Cleanup();
	}

    private void OnDestroy()
    {
        //_systems.TearDown();
    }
}
