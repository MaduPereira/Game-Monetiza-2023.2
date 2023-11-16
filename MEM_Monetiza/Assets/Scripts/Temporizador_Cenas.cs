using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador_Cenas : MonoBehaviour
{
    [SerializeField] Barra_Tempo_Cenas barraHorizontal;

    [SerializeField] private float tempoMaximo;
    private float tempoAtual;

    private bool ligado;

    private void Start()
    {
        tempoAtual = tempoMaximo;
        barraHorizontal.DefinirValorMaximo(tempoMaximo);
        IniciaTemporizador();//para começar a dimnuir a barra de tempo
    }

    private void Update()
    {
        if (ligado)
        {
            tempoAtual -= Time.deltaTime;

            barraHorizontal.AtualizarBarra(tempoAtual);

            if (tempoAtual <= 0)
            {
                ligado = false;
            }
        }
    }

    public void ReiniciaTemporizador() //para reinicar a barra
    {
        barraHorizontal.AtualizarBarra(tempoMaximo);
        tempoAtual = tempoMaximo;
        ligado = false;
    }

    public void IniciaTemporizador()
    {
        ligado = true;
    }
}
