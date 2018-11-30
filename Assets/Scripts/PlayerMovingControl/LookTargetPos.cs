using UnityEngine;
using System.Collections;

public class LookTargetPos : MonoBehaviour
{
    public SelectedComponent selected;

    public Vector3 targetPos;//用来保存鼠标点击到地面的位置
    private bool isMouseDown = false;//判断鼠标左键是否一直按下

    void Start()
    {
        targetPos = this.transform.position;
        selected = GetComponent<SelectedComponent>();
    }


    void Update()
    {
        //检查是否选中
        if (!selected.isSelected)
            return;

        if (Input.GetMouseButtonDown(1))
        {
            isMouseDown = true;
            LookAtPos();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isMouseDown = false;
        }
        //如果鼠标左键一直按下，则一直更新鼠标位置
        if (isMouseDown == true)
        {
            LookAtPos();
        }

        //避免碰撞转向 暂时这样处理
        this.transform.LookAt(targetPos);
     }

    void LookAtPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;
        bool isCollider = Physics.Raycast(ray, out hitinfo);
        //判断鼠标是否点击地面
        if (isCollider == true && hitinfo.collider.tag == "Ground")
        {
            targetPos = hitinfo.point;
            targetPos.y = this.transform.position.y;
            this.transform.LookAt(targetPos);
            
        }
    }
}
