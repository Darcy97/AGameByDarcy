using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour {

	public void OnLoadGameButtonClick(int level)
    {
        SceneManager.LoadScene(level);
    }
}
