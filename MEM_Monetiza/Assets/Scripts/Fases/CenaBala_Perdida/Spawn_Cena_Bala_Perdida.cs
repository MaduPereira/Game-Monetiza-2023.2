using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Cena_Bala_Perdida : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn; // Objeto a ser spawnado
    [SerializeField] float minSpawnDelay = 0.2f; // Tempo m�nimo entre spawns
    [SerializeField] float maxSpawnDelay = 2f; // Tempo m�ximo entre spawns

    [SerializeField] Transform player; // Refer�ncia para o jogador

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay); // Tempo aleat�rio entre spawns 
        if (Banco_Globais.startFase == true)
        {
            Instantiate(objectToSpawn, player.position, Quaternion.identity); // Spawn do objeto na posi��o do jogador 
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnObjects());
    }
}
