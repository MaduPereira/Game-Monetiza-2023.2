using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladoDeScene : MonoBehaviour
{
    // Nome da cena para a qual você deseja mudar
    public string nomeDaNovaCena, nomeDaNovaCena02, nomeDaNovaCena03;

    // Método chamado quando o botão é clicado
    public void OnClickTrocarCena()
    {
        // Carregar a nova cena
        SceneManager.LoadScene(nomeDaNovaCena);
    }

     public void OnClickTrocarCena02()
    {
        // Carregar a nova cena
        SceneManager.LoadScene(nomeDaNovaCena02);
    }

      public void OnClickTrocarCena03()
    {
        // Carregar a nova cena
        SceneManager.LoadScene(nomeDaNovaCena03);
    }
}