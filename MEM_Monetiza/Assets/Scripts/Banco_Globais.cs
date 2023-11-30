using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wilberforce;

public class Banco_Globais : MonoBehaviour
{
    //cada fase completa ganha 100 pontos
    //bonos hr x1.4 -- funciona quando vc ganha 3 fases seguidas come�a 1.1, 1.2 ....
    //quanto mais ganha o tempo passa mais rapido

    //A cada tr�s jogos, o jogo acelera.�Existem varia��es do texto "mais r�pido", como a mudan�a de "mais r�pido" para "mais r�pido"
    //(embora as pessoas n�o pensem que "mais r�pido" seja uma palavra) e o aparecimento de v�rios textos "mais r�pidos".

    //playerprefabs

    // Start is called before the first frame update
    public GameObject Canvas_Configura��es;

    //Acessibility
    public GameObject Canvas_Acessibility, Slade_Zoom;
    CamZoon cam_Script;

    Colorblind dalto_Script;
    int daltoType = 4;
    public Dropdown TypeDaltonism, TypeZoom;

    public GameObject ButaoSon_ON, ButaoSon_OFF;

    private void Awake()
    {
        Canvas_Acessibility.SetActive(false);
        Slade_Zoom.SetActive(false);
        Canvas_Configura��es.SetActive(false);
    }

    private void Start()
    {
        // Atribuir o componente Colorblind da c�mera principal � vari�vel dalto
        dalto_Script = Camera.main.GetComponent<Colorblind>();
        cam_Script = GetComponent<CamZoon>();
    }

    #region Daltonismo option
    public void ChangeDaltonismType() // M�todo chamado quando a op��o do Dropdown muda
    {
        // Verificar o �ndice selecionado no Dropdown
        int selectedIndex = TypeDaltonism.value;

        // Atribuir o tipo de daltonismo com base no �ndice selecionado
        dalto_Script.Type = selectedIndex;
    }

    public void ChangeZoomType()
    {
        // Verificar o �ndice selecionado no slade
        int selectedIndex = TypeZoom.value;

        // Atribuir o tipo de zoom com base no �ndice selecionado
        cam_Script.Type = selectedIndex;

        if (selectedIndex == 1)
        {
            Slade_Zoom.SetActive(true);
        }
        else
        {
            Slade_Zoom.SetActive(false); // Desativar o Slade_Zoom se o selectedIndex n�o for igual a 1
        }

        cam_Script.GetComponent<CamZoon>().UpdateZoomType();
    }

    public void CloseAcessibility()
    {
        Canvas_Acessibility.SetActive(false);
    }
    #endregion

    #region Buttons Menu
    public void OpenConfigura��es()
    {
        Canvas_Configura��es.SetActive(true);
    }
    public void CloseConfigura��es()
    {
        Canvas_Configura��es.SetActive(false);
    }
    public void OpenAcessibility()
    {
        Canvas_Acessibility.SetActive(true);
    }

    #endregion
}
