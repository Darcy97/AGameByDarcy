﻿using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour {

	public void OnStartGameButtonClick()
    {
        SceneManager.LoadScene(1);
    }

}
