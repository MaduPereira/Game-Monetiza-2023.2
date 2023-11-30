using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wilberforce;

public class Banco_Globais : MonoBehaviour
{
    //cada fase completa ganha 100 pontos
    //bonos hr x1.4 -- funciona quando vc ganha 3 fases seguidas começa 1.1, 1.2 ....
    //quanto mais ganha o tempo passa mais rapido

    //A cada três jogos, o jogo acelera. Existem variações do texto "mais rápido", como a mudança de "mais rápido" para "mais rápido"
    //(embora as pessoas não pensem que "mais rápido" seja uma palavra) e o aparecimento de vários textos "mais rápidos".

    //playerprefabs

    // Start is called before the first frame update
    public GameObject Canvas_Configurações;

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
        Canvas_Configurações.SetActive(false);
    }

    private void Start()
    {
        // Atribuir o componente Colorblind da câmera principal à variável dalto
        dalto_Script = Camera.main.GetComponent<Colorblind>();
        cam_Script = GetComponent<CamZoon>();
    }

    #region Daltonismo option
    public void ChangeDaltonismType() // Método chamado quando a opção do Dropdown muda
    {
        // Verificar o índice selecionado no Dropdown
        int selectedIndex = TypeDaltonism.value;

        // Atribuir o tipo de daltonismo com base no índice selecionado
        dalto_Script.Type = selectedIndex;
    }

    public void ChangeZoomType()
    {
        // Verificar o índice selecionado no slade
        int selectedIndex = TypeZoom.value;

        // Atribuir o tipo de zoom com base no índice selecionado
        cam_Script.Type = selectedIndex;

        if (selectedIndex == 1)
        {
            Slade_Zoom.SetActive(true);
        }
        else
        {
            Slade_Zoom.SetActive(false); // Desativar o Slade_Zoom se o selectedIndex não for igual a 1
        }

        cam_Script.GetComponent<CamZoon>().UpdateZoomType();
    }

    public void CloseAcessibility()
    {
        Canvas_Acessibility.SetActive(false);
    }
    #endregion

    #region Buttons Menu
    public void OpenConfigurações()
    {
        Canvas_Configurações.SetActive(true);
    }
    public void CloseConfigurações()
    {
        Canvas_Configurações.SetActive(false);
    }
    public void OpenAcessibility()
    {
        Canvas_Acessibility.SetActive(true);
    }

    #endregion
}
