using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Cena_Bala_Perdida : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn; // Objeto a ser spawnado
    [SerializeField] float minSpawnDelay = 0.2f; // Tempo mínimo entre spawns
    [SerializeField] float maxSpawnDelay = 2f; // Tempo máximo entre spawns

    [SerializeField] Transform player; // Referência para o jogador

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay); // Tempo aleatório entre spawns 
        if (Banco_Globais.startFase == true)
        {
            Instantiate(objectToSpawn, player.position, Quaternion.identity); // Spawn do objeto na posição do jogador 
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnObjects());
    }
}
