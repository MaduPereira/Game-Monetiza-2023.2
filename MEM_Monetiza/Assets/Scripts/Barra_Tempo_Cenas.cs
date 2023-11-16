using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra_Tempo_Cenas : MonoBehaviour
{
    [SerializeField] private RectTransform barra;

    [SerializeField] private float tamanhoMaximo;
    private float tamanhoAtual;

    private float valorMaximo;

    public void DefinirValorMaximo(float _valorMaximo)
    {
        valorMaximo = _valorMaximo;
    }

    public void AtualizarBarra(float _valorAtual)
    {
        tamanhoAtual = _valorAtual * tamanhoMaximo / valorMaximo;
        barra.sizeDelta = new Vector2(tamanhoAtual, barra.sizeDelta.y);
    }
}
