using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladrao_Casa : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.WorldToScreenPoint(touch.position);

            /*if(touchPos //colidir com o ladrao)
            {
                //impede que ele asssalte a casa
            }
            else
            {
                //ele rouba a casa
            }*/
        }
    }
}
