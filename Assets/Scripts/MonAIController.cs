using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonAIController : MonoBehaviour {

    public Transform target;  //AI 目标
    private CharacterController m_characterController;

    private Vector3 target_posion;

    const float speed = 1f;


	void Start () {

        m_characterController = GetComponent<CharacterController>();
        
	}
	
	void Update () {

        

	}



    private void FixedUpdate()
    {
        target_posion = target.position;

        Vector3 direction = Time.deltaTime * speed * (target.position - transform.position).normalized;
        direction.y = 0;

        m_characterController.Move(direction*Time.fixedDeltaTime*speed);
    }
}
