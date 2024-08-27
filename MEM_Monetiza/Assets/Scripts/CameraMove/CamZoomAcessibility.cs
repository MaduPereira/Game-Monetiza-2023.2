using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamZoomAcessibility : MonoBehaviour
{
    Vector3 touchPosWorld;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    public Slider sliderZoom; // Refer�ncia ao slider na interface do Unity

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
            {
                touchPosWorld = Camera.main.ScreenToWorldPoint(toque.position);
            }
            if (toque.phase == TouchPhase.Moved)
            {
                Vector3 direcao = touchPosWorld - Camera.main.ScreenToWorldPoint(toque.position);
                Camera.main.transform.position += direcao;
            }
        }
    }

    public void SliderZoom()
    {
        float novoZoom = sliderZoom.value; // Obt�m o valor do slider
        Camera.main.GetComponent<Camera>().fieldOfView = Mathf.Clamp(novoZoom, zoomOutMin, zoomOutMax);
    }
}
