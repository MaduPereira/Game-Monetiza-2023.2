using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladrao_Casa : MonoBehaviour
{
    [SerializeField] float speed;
    public GameObject Bastao, cofreF, cofreA;
    Transform Ladrao;
    public SpriteRenderer LadraoIdle, LadraoWalk;

    private void Start()
    {
        LadraoIdle = GetComponent<SpriteRenderer>();
        LadraoWalk = GetComponent<SpriteRenderer>();
        //LadraoIdle.enabled = true;
        //LadraoWalk.enabled = false; 
        Ladrao = GetComponent<Transform>();
        cofreF.SetActive(true); 
        cofreA.SetActive(false);
    }

    void Update()
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
                    Bastao.transform.position = Ladrao.position;
                }
            }
        }
        if(Ladrao.position == Bastao.transform.position)
        {
            transform.position = transform.position;
            LadraoIdle.enabled = true;
            LadraoWalk.enabled = false;
        }
        else if(Ladrao.GetComponent<Collider2D>().transform == cofreF.GetComponent<Collider2D>().transform)
        {
            transform.position = transform.position;
            cofreF.SetActive(false);
            cofreA.SetActive(true);
            LadraoIdle.enabled = true;
            LadraoWalk.enabled = false;
        }
        else
        {
            LadraoIdle.enabled = false;
            LadraoWalk.enabled = true;
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
