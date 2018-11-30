using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour
{

    private PlayerMove playerState;
    private float distance;
    private Animation m_animation;

    // Use this for initialization
    void Start()
    {
        playerState = this.GetComponent<PlayerMove>();
        m_animation = transform.Find("body").GetComponent<Animation>();
        foreach (AnimationState item in m_animation)
        {
            item.speed = 0.5f;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //如果游戏主角在移动就播放跑的动画
        if (playerState.state == Playerstate.Moveing)
        {
            PlayAnimation("Move1");
        }
        //如果游戏主角在等待就播放站的动画
        else if (playerState.state == Playerstate.Idle)
        {
            PlayAnimation("Idle1");
        }
    }
    void PlayAnimation(string animationName)
    {
        m_animation.Play(animationName);
    }
}