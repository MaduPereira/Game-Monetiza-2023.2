using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Cena_Bala_Perdida : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn; // Objeto a ser spawnado
    [SerializeField] float minSpawnDelay = 1f; // Tempo mínimo entre spawns
    [SerializeField] float maxSpawnDelay = 3f; // Tempo máximo entre spawns

    [SerializeField] Transform player; // Referência para o jogador

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            Instantiate(objectToSpawn, player.position, Quaternion.identity); // Spawn do objeto na posição do jogador

            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay); // Tempo aleatório entre spawns
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
