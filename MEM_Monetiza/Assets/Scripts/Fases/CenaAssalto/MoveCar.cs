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
        if(Input.touchCount > 0)
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

        if(Banco_Globais.FinishGame == true)
        {
            if(transform.position == Camera.main.transform.position)
            {
                Banco_Globais.SitPerdeu = true;
                GameOver.SetActive(true);
            }     
        }
        else
        {
            GameOver.SetActive(false);
        }
        
    }
}
