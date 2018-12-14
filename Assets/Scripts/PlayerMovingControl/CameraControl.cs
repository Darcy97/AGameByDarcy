using UnityEngine;

/// <summary>
/// 1.  随鼠标移动屏幕
/// 2.  鼠标滚轮 page up down 缩放
/// 3.  旋转屏幕（待定）
/// </summary>
public class CameraControl : MonoBehaviour
{

    #region Var
    private Vector3 followPos;            //用来保存摄像机和游戏主角的相对位置
    public GameObject player;             //旋转中心 
    private bool isRotating = false;      //判断鼠标中键是否按下
    private float camera_distance_k = 1;
    private float camera_field_size;
    #endregion

    #region const
    private const float scrollSpeed = 1;        //摄像机拉近的速度
    private const float rotateSpeed = 2;        //摄像机左右旋转的速度
    private const float camera_move_speed = 10; //摄像机移动速度
    #endregion

    #region Mono Event
    void Start()
    {
        camera_field_size = Camera.main.fieldOfView;
    }

    void Update()
    {
        RotateView();
        ScrollView();
        CameraMoveToMouse();
    }
    #endregion

    #region Method
    /// <summary>
    /// 滑动鼠标滑轮的时候可以改变摄像机高度
    /// </summary>
    void ScrollView()
    {
        if (Input.GetMouseButtonDown(2))
            return;

        if (Input.GetButtonDown("Page Down"))
        {
            ResetCameraPostion(0.7f);
        }
        if (Input.GetButtonDown("Page Up"))
        {
            ResetCameraPostion(1.3f);
        }
    }

    void ResetCameraPostion(float k)
    {       
        camera_field_size *= k;
        camera_field_size = Mathf.Clamp(camera_field_size, 5, 120);
        Camera.main.fieldOfView = camera_field_size;
    }


    /// <summary>
    /// 鼠标滚轮调整视角
    /// </summary>
    private void RotateView()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.rotation.x < 0.5 || 
            Input.GetAxis("Mouse ScrollWheel") < 0 && transform.rotation.x > 0.2)
        {
            transform.Rotate(new Vector3(100 * Input.GetAxis("Mouse ScrollWheel"), 0, 0));
            ResetCameraPostion(1 + Input.GetAxis("Mouse ScrollWheel"));
        }
        return;
    }

    /// <summary>
    /// 相机跟随鼠标移动，当鼠标移出屏幕相机跟随移动
    /// </summary>
    private void CameraMoveToMouse()
    {
        if (Input.GetMouseButtonDown(2))
            return;

        Vector3 v1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (v1.x < 0.0005f)
        {
            transform.Translate(-Vector3.right * camera_move_speed * Time.deltaTime, Space.World);
        }
        if (v1.x > 1 - 0.0005f)
        {
            transform.Translate(Vector3.right * camera_move_speed * Time.deltaTime, Space.World);
        }
        if (v1.y < 0.0005f)
        {
            transform.Translate(Vector3.back * camera_move_speed * Time.deltaTime, Space.World);
        }
        if (v1.y > 1 - 0.0005f)
        {
            transform.Translate(Vector3.forward * camera_move_speed * Time.deltaTime, Space.World);
        }
    }
    #endregion
}