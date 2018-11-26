using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMonsterController : MonoBehaviour {

    private static float m_animation_speed = 0.5f;

	
	void Start () {
        Animation animation = transform.Find("body").GetComponent<Animation>();
        foreach (AnimationState item in animation)
        {
            item.speed = m_animation_speed; 
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
