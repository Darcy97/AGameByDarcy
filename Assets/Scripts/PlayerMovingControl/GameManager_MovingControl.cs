using UnityEngine;

class GameManager_MovingControl: MonoBehaviour
{
    private static GameManager_MovingControl _instance;

    public static GameManager_MovingControl Instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager_MovingControl();
            }

            return _instance;
        }
        set { _instance = value; }
    }

    [HideInInspector]
    public GameObject Arrow;

    private void Start()
    {
        Arrow = Resources.Load<GameObject>("Objects/3D/Model/Arrow/Arrow_Green");
    }
}

