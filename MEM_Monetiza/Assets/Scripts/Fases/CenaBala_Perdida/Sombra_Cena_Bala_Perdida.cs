using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombra_Cena_Bala_Perdida : MonoBehaviour
{
    [SerializeField] float minSize = 0.5f; // Tamanho mínimo
    [SerializeField] float maxSize = 2f; // Tamanho máximo
    [SerializeField] float duration = 2f; // Duração da transição

    [SerializeField] GameObject bala;

    Vector3 originalScale; // Escala original do objeto
    float timer = 0f; // Timer para controlar o tempo da transição

    void Start()
    {
        originalScale = transform.localScale;
        transform.localScale = originalScale * minSize; // Começa com o objeto reduzido
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration); // Calcula o tempo atual

        // Aumenta gradualmente o tamanho do objeto até o tamanho original
        transform.localScale = Vector3.Lerp(originalScale * minSize, originalScale * maxSize, t);

        if (t >= 1f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(bala, transform.position, bala.transform.rotation);
            enabled = false; // Desativa o script quando atinge o tamanho original
        }
    }
}
