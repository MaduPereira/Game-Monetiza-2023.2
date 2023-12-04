using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temporizador_Cenas : MonoBehaviour
{
    [SerializeField] Barra_Tempo_Cenas barraHorizontal;

    [SerializeField] private float tempoMaximo;
    private float tempoAtual;

    private bool ligado;

    public GameObject canvas_pause;

    private void Start()
    {
        canvas_pause.SetActive(false);
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
                Banco_Globais.FinishGame = true;
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

    public void ButtonPause()
    {
        Time.timeScale = 0;
        canvas_pause.SetActive(true);
    }

    public void buttonSair()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonContinuar()
    {
        Time.timeScale = 1;
        canvas_pause.SetActive(false);
    }
}
