using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamZoon : MonoBehaviour
{
    Vector3 touchPosWorld;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    public float mapMinX, mapMaxX, mapMinY, mapMaxY;

    public Slider slider;

    public int Type = 0;

    private void Update()
    {
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroprevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneprevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroprevPos - touchOneprevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);

        }
        else if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchPosWorld = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 direction = touchPosWorld - Camera.main.ScreenToWorldPoint(touch.position);
                Camera.main.transform.position += direction;
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

        float newX = Mathf.Clamp(targtPos.x, minX, maxX);
        float newY = Mathf.Clamp(targtPos.y, minY, maxY);

        return new Vector3(newX, newY, targtPos.z);
    }

}
