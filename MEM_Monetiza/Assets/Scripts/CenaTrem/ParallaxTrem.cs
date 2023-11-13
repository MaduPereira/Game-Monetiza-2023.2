using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTrem : MonoBehaviour
{
    private float length, startpos;

    private Transform cam;

    public float ParallaxeEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float Repos = cam.transform.position.x * (1 - ParallaxeEffect);
        float Distance = cam.transform.position.x * ParallaxeEffect;

        transform.position = new Vector3(startpos + Distance, transform.position.y, transform.position.z);

        if(Repos > startpos + length)
        {
            startpos += length;
        }
        else if(Repos < startpos - length)
        {
            startpos -= length;
        }

    }
}
