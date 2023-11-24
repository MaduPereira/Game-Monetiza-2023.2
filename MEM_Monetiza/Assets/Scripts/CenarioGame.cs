using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioGame : MonoBehaviour
{
    public GameObject NuvemD, NuvemE; // Objeto a ser spawnado
    public Transform SpawnD, SpawnE; // �rea onde os objetos ser�o spawnados
    public float minY = 3f; // Valor m�nimo para a posi��o y
    public float maxY = 8f; // Valor m�ximo para a posi��o y
    public float minX = -20f; // Valor m�nimo para a posi��o y
    public float maxX = 20f; // Valor m�ximo para a posi��o y
    public float minSpawnDelay = 1f; // Atraso m�nimo entre os spawns
    public float maxSpawnDelay = 3f; // Atraso m�ximo entre os spawns

    void Start()
    {
        // Inicia o m�todo de spawn de objetos em intervalos aleat�rios
        Invoke("SpawnNuvens", Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    void SpawnNuvens()
    {
        // Calcula uma posi��o aleat�ria dentro da �rea especificada para NuvemD
        float randomDX = Random.Range(minX, maxX);
        float randomDY = Random.Range(minY, maxY);
        Vector3 spawnPosition1 = new Vector3(randomDX, randomDY, 0f) + transform.position;

        // Calcula uma posi��o aleat�ria dentro da �rea especificada para NuvemE
        float randomEX = Random.Range(minX, maxX);
        float randomEY = Random.Range(minY, maxY);
        Vector3 spawnPosition2 = new Vector3(randomEX, randomEY, 0f) + transform.position;

        // Instancia o objeto na posi��o calculada
        GameObject clone1 = Instantiate(NuvemD, spawnPosition1, Quaternion.identity);
        GameObject clone2 = Instantiate(NuvemE, spawnPosition2, Quaternion.identity);

        Destroy(clone1, 20);
        Destroy(clone2, 20);

        // Define o pr�ximo spawn ap�s um tempo aleat�rio
        Invoke("SpawnNuvens", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
