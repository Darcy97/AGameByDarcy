using UnityEngine;

public class CameraHYP : MonoBehaviour
{

    const float degree = 0.0005f;

    void Update() {
        Vector3 v1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (v1.x < degree)
        {
            transform.Translate(-Vector3.right * 10 * Time.deltaTime, Space.World);
        }
        if (v1.x > 1 - degree)
        {
            transform.Translate(Vector3.right * 10 * Time.deltaTime, Space.World);
        }
        if (v1.y < degree)
        {
            transform.Translate(Vector3.back * 10 * Time.deltaTime, Space.World);
        }
        if (v1.y > 1 - degree)
        {
            transform.Translate(Vector3.forward * 10 * Time.deltaTime, Space.World);
        }
    }
}

