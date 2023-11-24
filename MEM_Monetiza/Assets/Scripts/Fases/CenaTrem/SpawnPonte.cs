using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPonte : MonoBehaviour
{
    [SerializeField] GameObject Ponte;
    [SerializeField] float widht, height;
    [SerializeField] float maxTimer = 1f;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newObstaculo = Instantiate(Ponte);
        newObstaculo.transform.position = transform.position + new Vector3(widht, height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTimer)
        {
            GameObject newObstaculo = Instantiate(Ponte);
            newObstaculo.transform.position = transform.position + new Vector3(widht, height, 0);
            Destroy(newObstaculo, 20f);
            timer = 0f;
        }

        timer += Time.deltaTime;
    }
}
