using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrem : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
