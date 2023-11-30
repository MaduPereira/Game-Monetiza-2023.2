using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetores_City : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidade de rotação
    public float minZ, maxZ;
    private float currentRotation = 0f;

    void Update()
    {
        // Adiciona a rotação baseada na velocidade e no tempo
        currentRotation += rotationSpeed * Time.deltaTime;

        // Limita o ângulo de rotação entre minZ e maxZ
        if (currentRotation < minZ || currentRotation > maxZ)
        {
            rotationSpeed = -rotationSpeed; // Inverte a direção da rotação
        }

        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }
}
