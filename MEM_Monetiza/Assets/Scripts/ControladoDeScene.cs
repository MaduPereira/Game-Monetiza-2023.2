using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladoDeScene : MonoBehaviour
{
    public string[] minigameScenes; // Nomes das cenas dos minigames
    private List<int> randomMinigameIndices = new List<int>();
    private int currentMinigameIndex = -1;

    public string nomeDaNovaCena;

    // Método chamado quando o botão é clicado
    public void OnClickTrocarCena()
    {
        // Carregar a nova cena
        SceneManager.LoadScene(nomeDaNovaCena);
    }


    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            // Gerar uma lista aleatória de índices das cenas dos minigames
            GenerateRandomMinigameIndices();
        }
    }

    void GenerateRandomMinigameIndices()
    {
        // Gerar uma ordem aleatória para os índices das cenas dos minigames
        List<int> indices = new List<int>();
        for (int i = 0; i < minigameScenes.Length; i++)
        {
            indices.Add(i);
        }

        while (indices.Count > 0)
        {
            int randomIndex = Random.Range(0, indices.Count);
            randomMinigameIndices.Add(indices[randomIndex]);
            indices.RemoveAt(randomIndex);
        }
    }

    public void StartNextMinigame()
    {
        // Verificar se há mais minigames para jogar
        if (currentMinigameIndex < randomMinigameIndices.Count - 1)
        {
            currentMinigameIndex++;

            // Carregar a cena do próximo minigame usando o nome da cena
            SceneManager.LoadScene(minigameScenes[randomMinigameIndices[currentMinigameIndex]]);
        }
        else
        {
            GenerateRandomMinigameIndices();
        }
    }
}