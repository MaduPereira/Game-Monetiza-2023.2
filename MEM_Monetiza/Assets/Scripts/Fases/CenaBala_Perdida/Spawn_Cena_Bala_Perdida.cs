using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Cena_Bala_Perdida : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn; // Objeto a ser spawnado
    [SerializeField] float minSpawnDelay = 1f; // Tempo m�nimo entre spawns
    [SerializeField] float maxSpawnDelay = 3f; // Tempo m�ximo entre spawns

    [SerializeField] Transform player; // Refer�ncia para o jogador

    void Update()
    {
        if (Banco_Globais.startFase == true)
        {
            StartCoroutine(SpawnObjects());
        }
    }

    IEnumerator SpawnObjects()
    {
        Instantiate(objectToSpawn, player.position, Quaternion.identity); // Spawn do objeto na posi��o do jogador

        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay); // Tempo aleat�rio entre spawns
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnObjects());
    }
}
