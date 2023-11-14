using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombra_Cena_Bala_Perdida : MonoBehaviour
{
    [SerializeField] float minSize = 0.5f; // Tamanho m�nimo
    [SerializeField] float maxSize = 2f; // Tamanho m�ximo
    [SerializeField] float duration = 2f; // Dura��o da transi��o

    [SerializeField] GameObject bala;

    Vector3 originalScale; // Escala original do objeto
    float timer = 0f; // Timer para controlar o tempo da transi��o

    void Start()
    {
        originalScale = transform.localScale;
        transform.localScale = originalScale * minSize; // Come�a com o objeto reduzido
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration); // Calcula o tempo atual

        // Aumenta gradualmente o tamanho do objeto at� o tamanho original
        transform.localScale = Vector3.Lerp(originalScale * minSize, originalScale * maxSize, t);

        if (t >= 1f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(bala, transform.position, bala.transform.rotation);
            enabled = false; // Desativa o script quando atinge o tamanho original
        }
    }
}
