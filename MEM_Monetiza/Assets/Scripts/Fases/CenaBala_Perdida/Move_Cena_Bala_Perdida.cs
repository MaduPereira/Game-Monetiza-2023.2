using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Cena_Bala_Perdida : MonoBehaviour
{
    [SerializeField] float speed;
    bool isMoving = false;
    Vector3 targetPosition;

    void Update()
    {
        if (Banco_Globais.startFase == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    isMoving = true;
                    targetPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    targetPosition.z = 0;

                    // Limitando a posição dentro dos valores desejados
                    targetPosition.x = Mathf.Clamp(targetPosition.x, -5f, 5f);
                    targetPosition.y = Mathf.Clamp(targetPosition.y, -3f, 1f);
                }
            }

            if (isMoving)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                if (transform.position == targetPosition)
                {
                    isMoving = false;
                }
            }
        }
    }
}
