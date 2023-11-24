using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoon : MonoBehaviour
{
    Vector3 touchPosWorld;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    public float mapMinX, mapMaxX, mapMinY, mapMaxY;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchPosWorld = Camera.main.ScreenToWorldPoint(touch.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 direction = touchPosWorld - Camera.main.ScreenToWorldPoint(touch.position);
                Camera.main.transform.position += direction;
            } 
        }
        if(Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 direction = touchPosWorld - Camera.main.ScreenToWorldPoint(touch.position);
                Camera.main.transform.position += direction;
                zoom(direction.x - direction.y);
            }
        }
        Camera.main.transform.position = LimiteCam(Camera.main.transform.position);
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    Vector3 LimiteCam(Vector3 targtPos)
    {
        float CamHeight = Camera.main.orthographicSize;
        float CamWidth = Camera.main.orthographicSize * Camera.main.aspect;

        float minX = mapMinX + CamWidth;
        float maxX = mapMaxX - CamWidth;

        float minY = mapMinY + CamHeight;
        float maxY = mapMaxY - CamHeight;

        float newX = Mathf.Clamp(targtPos.x , minX, maxX);
        float newY = Mathf.Clamp(targtPos.y, minY, maxY);

        return new Vector3(newX, newY, targtPos.z);
    }
}
