using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ladrao_Casa : MonoBehaviour
{
    [SerializeField] float speed;
    public GameObject Bastao, cofreF, cofreA;
    Transform Ladrao;
    public SpriteRenderer LadraoIdle, LadraoWalk;
    public bool coll = false;

    private void Start()
    {
        Bastao.GetComponent<SpriteRenderer>().sortingOrder = 0;
        coll = false;
        LadraoIdle.enabled = true;
        LadraoWalk.enabled = false;
        Ladrao = GetComponent<Transform>();
        cofreF.SetActive(true); 
        cofreA.SetActive(false);
    }

    void Update()
    {
        if(Banco_Globais.startFase == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

                    if (hit.collider != null && hit.collider.transform == Ladrao)
                    {
                        Bastao.GetComponent<SpriteRenderer>().sortingOrder = 2;
                        Bastao.transform.position = Ladrao.position;
                        Banco_Globais.FinishGame = true;
                    }
                }
            }

            if (Ladrao.position == Bastao.transform.position && coll == false)
            {
                transform.position = transform.position;
                LadraoIdle.enabled = true;
                LadraoWalk.enabled = false;
            }
            else if (coll == false)
            {
                LadraoIdle.enabled = false;
                LadraoWalk.enabled = true;
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        } 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            Banco_Globais.SitPerdeu = true;
            coll = true;
            Debug.Log("to aqui");
            cofreF.SetActive(false);
            cofreA.SetActive(true);
            LadraoIdle.enabled = true;
            LadraoWalk.enabled = false;
            transform.position = transform.position;
        }
    }
}
