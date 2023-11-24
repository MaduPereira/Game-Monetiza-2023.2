using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioGame : MonoBehaviour
{
    public GameObject NuvemD, NuvemE; // Objeto a ser spawnado
    public Transform SpawnD, SpawnE; // Área onde os objetos serão spawnados
    public float minY = 3f; // Valor mínimo para a posição y
    public float maxY = 8f; // Valor máximo para a posição y
    public float minX = -20f; // Valor mínimo para a posição y
    public float maxX = 20f; // Valor máximo para a posição y
    public float minSpawnDelay = 1f; // Atraso mínimo entre os spawns
    public float maxSpawnDelay = 3f; // Atraso máximo entre os spawns

    void Start()
    {
        // Inicia o método de spawn de objetos em intervalos aleatórios
        Invoke("SpawnNuvens", Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    void SpawnNuvens()
    {
        // Calcula uma posição aleatória dentro da área especificada para NuvemD
        float randomDX = Random.Range(minX, maxX);
        float randomDY = Random.Range(minY, maxY);
        Vector3 spawnPosition1 = new Vector3(randomDX, randomDY, 0f) + transform.position;

        // Calcula uma posição aleatória dentro da área especificada para NuvemE
        float randomEX = Random.Range(minX, maxX);
        float randomEY = Random.Range(minY, maxY);
        Vector3 spawnPosition2 = new Vector3(randomEX, randomEY, 0f) + transform.position;

        // Instancia o objeto na posição calculada
        GameObject clone1 = Instantiate(NuvemD, spawnPosition1, Quaternion.identity);
        GameObject clone2 = Instantiate(NuvemE, spawnPosition2, Quaternion.identity);

        Destroy(clone1, 20);
        Destroy(clone2, 20);

        // Define o próximo spawn após um tempo aleatório
        Invoke("SpawnNuvens", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
