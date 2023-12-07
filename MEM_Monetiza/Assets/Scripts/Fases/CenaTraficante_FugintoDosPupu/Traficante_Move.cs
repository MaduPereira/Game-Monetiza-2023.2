using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traficante_Move : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        if (Banco_Globais.startFase == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                }
                else
                {
                    transform.position = transform.position;
                }
            }
        }

        if (Banco_Globais.FinishGame == true)
        {
            //se o ladrao está dentro da área visível da câmera
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
            bool dentroDaAreaDaCamera = (viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1);

            if (dentroDaAreaDaCamera)
            {
                //se o ladrao estiver dentro da área visível da câmera
                Banco_Globais.SitPerdeu = true;
                //Banco_Globais.FinishGame = true;
            }
        }
    }
}
