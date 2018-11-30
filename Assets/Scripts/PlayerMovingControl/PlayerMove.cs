using UnityEngine;
using System.Collections;

public enum Playerstate
{
    Moveing,
    Idle,
    Default
}
public class PlayerMove : MonoBehaviour
{

    private CharacterController controller;
    public int speed = 4;
    private float distance;//用来保存游戏主角和目标点的距离
    public Playerstate state;//保存游戏主角的状态
    // Use this for initialization
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        state = Playerstate.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        distance = Vector3.Distance(this.transform.position, GetComponent<LookTargetPos>().targetPos);
        if (distance > 0.05f)
        {
            controller.SimpleMove(this.transform.forward * speed);
            state = Playerstate.Moveing;
        }
        else
        {
            state = Playerstate.Idle;
        }
    }
}