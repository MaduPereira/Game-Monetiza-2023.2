using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetores_City : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidade de rota��o
    public float minZ, maxZ;
    private float currentRotation = 0f;

    void Update()
    {
        // Adiciona a rota��o baseada na velocidade e no tempo
        currentRotation += rotationSpeed * Time.deltaTime;

        // Limita o �ngulo de rota��o entre minZ e maxZ
        if (currentRotation < minZ || currentRotation > maxZ)
        {
            rotationSpeed = -rotationSpeed; // Inverte a dire��o da rota��o
        }

        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }
}
