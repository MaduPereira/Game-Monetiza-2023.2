using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstaculos : MonoBehaviour
{
    [SerializeField] GameObject[] Obstaculo;
    [SerializeField] float widht, height;
    [SerializeField] float maxTimer = 1f;
    int RandonIndex;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        RandonIndex = Random.Range(0, 2);
        GameObject newObstaculo = Instantiate(Obstaculo[RandonIndex]);
        newObstaculo.transform.position = transform.position + new Vector3(widht, height, 0);
        Debug.Log(RandonIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTimer)
        {
            RandonIndex = Random.Range(0, 2);
            GameObject newObstaculo = Instantiate(Obstaculo[RandonIndex]);
            newObstaculo.transform.position = transform.position + new Vector3(widht, height, 0);
            Destroy(newObstaculo, 20f);
            timer = 0f;
        }

        Debug.Log(RandonIndex);

        timer += Time.deltaTime;
    }
}
