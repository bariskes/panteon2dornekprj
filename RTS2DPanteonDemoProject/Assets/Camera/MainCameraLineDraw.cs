using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraLineDraw : MonoBehaviour
{

    private Camera cam;
    private LineRenderer ln;
    void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
        ln = GetComponent<LineRenderer>();

    }

    void LateUpdate()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        // in case of need;
        Vector3 leftButtom = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 rightButtom = cam.ViewportToWorldPoint(new Vector2(1, 0));
        Vector3 leftTop = cam.ViewportToWorldPoint(new Vector2(0, 1));
        Vector3 rightTop = cam.ViewportToWorldPoint(new Vector2(1, 1));
        ln.transform.position = new Vector2(leftTop.x, leftTop.y);
        ln.startColor = Color.red;
        ln.endColor = Color.red;
        ln.startWidth = 0.5f;
        ln.endWidth = 0.5f;
    }
}

