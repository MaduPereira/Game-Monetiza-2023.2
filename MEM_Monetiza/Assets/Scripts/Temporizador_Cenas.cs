using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temporizador_Cenas : MonoBehaviour
{
    [SerializeField] Barra_Tempo_Cenas barraHorizontal;

    [SerializeField] private float tempoMaximo;
    private float tempoAtual;

    public static bool ligado;

    public GameObject canvas_pause;

    private void Start()
    {
        canvas_pause.SetActive(false);
        tempoAtual = tempoMaximo;
        barraHorizontal.DefinirValorMaximo(tempoMaximo);
        IniciaTemporizador();//para come�ar a dimnuir a barra de tempo
    }

    private void Update()
    {
        if (ligado)
        {
            tempoAtual -= Time.deltaTime;

            barraHorizontal.AtualizarBarra(tempoAtual);

            if (tempoAtual <= 0)
            {
                Debug.Log("Acabou o tempo");
                Banco_Globais.FinishGame = true;
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

    public void ButtonPause()
    {
        Time.timeScale = 0;
        canvas_pause.SetActive(true);
    }

    public void buttonSair()
    {
        Banco_Globais.LoadMinigames = false;
        Banco_Globais.startFase = false;
        Banco_Globais.StartFastGames = false;
        SceneManager.LoadScene(1);
    }

    public void ButtonContinuar()
    {
        Time.timeScale = 1;
        canvas_pause.SetActive(false);
    }
}
