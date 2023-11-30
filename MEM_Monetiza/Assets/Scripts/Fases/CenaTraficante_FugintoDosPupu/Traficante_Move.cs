using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traficante_Move : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
            else
            {
                transform.position = transform.position;
            }
        }
    }
}
