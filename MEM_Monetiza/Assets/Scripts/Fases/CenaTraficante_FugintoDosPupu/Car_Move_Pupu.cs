using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move_Pupu : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        if (Banco_Globais.startFase == true)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;

            if(Banco_Globais.SitPerdeu == true)
            {
                transform.position += Vector3.down * 5f * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            transform.position += Vector3.down * 5f * Time.deltaTime;
            Banco_Globais.SitPerdeu = true;
            //Banco_Globais.FinishGame = true;
        }
    }
}
