using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move_Pupu : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
       transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
