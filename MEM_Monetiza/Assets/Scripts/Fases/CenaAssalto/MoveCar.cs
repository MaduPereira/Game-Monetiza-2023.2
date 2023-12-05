using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    [SerializeField] float speed;
    public GameObject GameOver;

    // Update is called once per frame
    void Update()
    {
        if(Banco_Globais.startFase == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Stationary)
                {
                    transform.position = transform.position;
                }
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }


        if(Banco_Globais.FinishGame == true)
{
            //se o carro está dentro da área visível da câmera
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
            bool dentroDaAreaDaCamera = (viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1);

            if (dentroDaAreaDaCamera)
            {
                //se o carro estiver dentro da área visível da câmera
                Banco_Globais.SitPerdeu = true;
                GameOver.SetActive(true);
                Banco_Globais.FinishGame = true;
            }
        }
        else
        {
            GameOver.SetActive(false);
        }

    }
}
