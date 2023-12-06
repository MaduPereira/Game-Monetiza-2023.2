using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrem : MonoBehaviour
{
    Rigidbody2D bd;
    Animator anim;
    [SerializeField] float movSpeed = 10f;
    [SerializeField] float screenWidth, horizontal;
    [SerializeField] SpriteRenderer dePe, Deitado, Morto;


    // Start is called before the first frame update
    void Start()
    {
        bd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dePe = GetComponent<SpriteRenderer>();
        screenWidth = Screen.width;

        //tratamentos para os sprites
        dePe.enabled = true;
        dePe.GetComponent<BoxCollider2D>().enabled = true;
        Deitado.enabled = false;
        Deitado.GetComponent<BoxCollider2D>().enabled = false;
        Morto.enabled = false;
        Morto.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //manter dentro da camera
        var distanceZ = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceZ)).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ)).x;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), transform.position.y);

        //movimentaçao

        //transform.position += Vector3.left * 2f * Time.deltaTime;

        if(Banco_Globais.startFase == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    StartCoroutine(timeSleep()); //deitar
                }

                /*if(touch.phase == TouchPhase.Stationary)
                {
                    if(touch.position.x > screenWidth/2)
                    {
                        horizontal = 1.0f;
                        transform.localScale = new Vector3(1,1,1);
                    }
                    if (touch.position.x < screenWidth / 2)
                    {
                        horizontal = -1.0f;
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                }*/
            }
            else
            {
                horizontal = 0.0f;
            }
        }
/*        anim.SetFloat("horinzoltal", horizontal);*/
    }

    private void FixedUpdate()
    {
        if(Banco_Globais.startFase == true)
        {
            bd.AddForce(new Vector2(horizontal * (movSpeed * 20f) * Time.deltaTime, 0));
        }
        
    }

    IEnumerator timeSleep()
    {
        dePe.enabled = false;
        dePe.GetComponent<BoxCollider2D>().enabled = false;
        Deitado.enabled = true;
        Deitado.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(2f);
        dePe.enabled = true;
        dePe.GetComponent<BoxCollider2D>().enabled = true;
        Deitado.enabled = false;
        Deitado.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            Banco_Globais.SitPerdeu = true;
            Banco_Globais.FinishGame = true;
            //Time.timeScale = 0;
            dePe.enabled = false;
            dePe.GetComponent<BoxCollider2D>().enabled = false;
            Deitado.enabled = false;
            Deitado.GetComponent<BoxCollider2D>().enabled = false;
            Morto.enabled = true;
            Morto.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
