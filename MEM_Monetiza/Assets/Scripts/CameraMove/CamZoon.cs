using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamZoon : MonoBehaviour
{
    Vector3 touchPosWorld;
    public float zoomOutMin = 1f;
    public float zoomOutMax = 8f;

    public float mapMinX, mapMaxX, mapMinY, mapMaxY;

    public Slider slider;

    public int Type = 0;

    private void Update()
    {
        if (Type == 1)
        {
            //sliderZoom(Mathf.Lerp(zoomOutMin, zoomOutMax, slider.value));
            zoom(Mathf.Lerp(zoomOutMin, zoomOutMax, slider.value));

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Verifica se o toque não está colidindo com o slider
                    if (!IsTouchOnSlider(touch.position))
                    {
                        touchPosWorld = Camera.main.ScreenToWorldPoint(touch.position);
                    }
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    // Verifica se o toque não está colidindo com o slider
                    if (!IsTouchOnSlider(touch.position))
                    {
                        Vector3 direction = touchPosWorld - Camera.main.ScreenToWorldPoint(touch.position);
                        Camera.main.transform.position += direction;
                    }
                }
            }
        }
        else
        {
            if (Input.touchCount == 2)
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
        }
        Camera.main.transform.position = LimiteCam(Camera.main.transform.position);
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    public void sliderZoom(float Zoom)
    {
        zoomOutMin = Zoom;
    }

    bool IsTouchOnSlider(Vector2 touchPosition)
    {
        // Converte a posição do toque para coordenadas de tela
        Vector2 touchPosWorld = Camera.main.ScreenToWorldPoint(touchPosition);

        // Verifica se há colisão com o Collider do slider
        Collider2D sliderCollider = slider.GetComponent<Collider2D>();
        if (sliderCollider != null)
        {
            return sliderCollider.OverlapPoint(touchPosWorld);
        }

        return false;
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
