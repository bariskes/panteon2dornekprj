using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMover : MonoBehaviour
{

    public Vector2 direction;
    public Camera MainCam;
    /// <summary>
    ///  camera  cant exit minimap Bounds;
    /// </summary>
    public Camera MiniMapCam;
    public float MoveSpeed = 5F;



    void Update()
    {
        /// keyboard based direction
        /// 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        direction = new Vector2(h * MoveSpeed, v * MoveSpeed);
        MainCam.transform.Translate(direction);
        MoveLimiter();

    }
    // cant exit minimap bounds
    void MoveLimiter()
    {
        Vector3 pos = MainCam.transform.position;
        Vector3 leftButtom = MiniMapCam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 rightButtom = MiniMapCam.ViewportToWorldPoint(new Vector2(1, 0));
        Vector3 leftTop = MiniMapCam.ViewportToWorldPoint(new Vector2(0, 1));
        float x = Clamper(pos.x, leftButtom.x, rightButtom.x);
        float y = Clamper(pos.y, leftButtom.y, leftTop.y);
        MainCam.transform.position = new Vector3(x, y, pos.z);
    }
    // clamps value between camera min and max coordinates
    float Clamper(float posaxis, float min, float max)
    {
        return Mathf.Clamp(posaxis, min, max);
    }




}

