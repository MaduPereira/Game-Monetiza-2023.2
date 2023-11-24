using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrem : MonoBehaviour
{
    [SerializeField] GameObject trem;
    [SerializeField] float widht, height;
    [SerializeField] float maxTimer = 1f;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newTrem = Instantiate(trem);
        newTrem.transform.position = transform.position + new Vector3(widht, height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTimer)
        {
            GameObject newTrem = Instantiate(trem);
            newTrem.transform.position = transform.position + new Vector3(widht, height, 0);
            Destroy(newTrem, 20f);
            timer = 0f;
        }

        timer += Time.deltaTime;
    }
}
