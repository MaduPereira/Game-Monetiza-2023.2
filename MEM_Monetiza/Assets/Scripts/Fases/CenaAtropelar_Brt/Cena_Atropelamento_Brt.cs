using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cena_Atropelamento_Brt : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    public SpriteRenderer PedestreFrente, PedestreCosta;

    public GameObject Bus;

    Vector3 posicaoOriginal;
    bool movendoParaCima = false;

    bool segurando = false;

    void Start()
    {
        PedestreFrente.enabled = true;
        PedestreCosta.enabled = false;
        posicaoOriginal = transform.position;
    }

    private void Update()
    {
        if(Banco_Globais.startFase == true)
        {
            if (Temporizador_Cenas.ligado == false && segurando == false)
            {
                Banco_Globais.SitPerdeu = true;
                Bus.transform.position += Vector3.left * 4f * Time.deltaTime;

                PedestreFrente.enabled = true;
                PedestreCosta.enabled = false;
                movendoParaCima = false;
                transform.position += Vector3.down * speed * Time.deltaTime;
                Banco_Globais.FinishGame = true;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Stationary)
                {
                    segurando = true;
                    if (!movendoParaCima)
                    {
                        PedestreCosta.enabled = true;
                        PedestreFrente.enabled = false;
                        transform.position += Vector3.up * speed * Time.deltaTime;
                    }
                }
                else
                {
                    segurando = false;
                }
            }

            if (transform.position.y > posicaoOriginal.y)
            {
                PedestreFrente.enabled = true;
                PedestreCosta.enabled = false;
                movendoParaCima = true;
            }
            else
            {
                movendoParaCima = false;
            }
        }
        
    }
}
