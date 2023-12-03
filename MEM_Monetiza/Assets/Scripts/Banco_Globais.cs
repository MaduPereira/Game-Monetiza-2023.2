using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Wilberforce;
using UnityEngine.SceneManagement;

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

    //points
    public GameObject[] WaitPoints;
    private SpriteRenderer[] spriteRenderers;
    private float originalAlpha;
    private Vector3 originalScale;

    //Legenda de GameObjects
    public GameObject[] objetosLegend;
    public Text Legenda;
    public GameObject painelLegenda;
    public float margem = 20f; // Margem para o texto

    //games
    ControladoDeScene SceneController;

    public GameObject canvasTemporizadorPrefab; // Prefab do Canvas Temporizador
    public bool LoadMinigames = false;


    private void Awake()
    {
        Canvas_Acessibility.SetActive(false);
        Slade_Zoom.SetActive(false);
        Canvas_Configurações.SetActive(false);
        painelLegenda.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().rootCount == 1)
        {
            // Atribuir o componente Colorblind da câmera principal à variável dalto
            dalto_Script = Camera.main.GetComponent<Colorblind>();
            cam_Script = GetComponent<CamZoon>();
            //cam_Script.enabled = true;

            // Armazenar os SpriteRenderers e valores originais
            spriteRenderers = new SpriteRenderer[WaitPoints.Length];
            for (int i = 0; i < WaitPoints.Length; i++)
            {
                spriteRenderers[i] = WaitPoints[i].GetComponent<SpriteRenderer>();
            }

            originalAlpha = spriteRenderers[0].color.a; // Supondo que todos têm a mesma opacidade
            originalScale = WaitPoints[0].transform.localScale; // Supondo que todos têm o mesmo tamanho

            // Modificar os objetos no início
            ModificarObjetos(1.0f, originalScale * 1.2f); // Aumentar o tamanho e remover a transparência
            Invoke("ResetarObjetos", 5.0f); // Chamar a função para resetar após 5 segundos
        }
        else
        {
            //cam_Script.enabled = false;

            SceneController = GetComponent<ControladoDeScene>();

            if (LoadMinigames == true)
            {
                // Verificar se o objeto Canvas Temporizador está presente na cena
                GameObject canvasTemporizador = GameObject.Find("canvasTemporizador");

                if (canvasTemporizador == null)
                {
                    // Se não estiver presente, instanciar o prefab do Canvas Temporizador
                    InstantiateCanvasTemporizador();
                }
            }
        }  
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().rootCount == 1)
        {
            // Legenda
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Obtemos o toque atual
                Touch touch = Input.GetTouch(0);

                // Converte a posição do toque para um raio na cena
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Se o raio atingir algum objeto na cena
                if (Physics.Raycast(ray, out hit))
                {
                    painelLegenda.SetActive(true);
                    // Verifica se o objeto atingido está na lista de objetos
                    foreach (GameObject obj in objetosLegend)
                    {
                        if (hit.collider.gameObject == obj)
                        {
                            // Exibe o nome do objeto atingido
                            MostrarLegenda(obj.name);
                            break;
                        }
                    }
                }
                else
                {
                    painelLegenda.SetActive(false);
                }
            }

            // Verifica se o Canvas de configurações está ativo
            if (Canvas_Configurações.activeSelf)
            {
                // Se estiver ativo, desabilita o script da câmera
                cam_Script.enabled = false;
            }
            else
            {
                // Se estiver desativado, habilita o script da câmera
                cam_Script.enabled = true;
            }

        }
    }

    void InstantiateCanvasTemporizador()
    {
        if (canvasTemporizadorPrefab != null)
        {
            // Instanciar o prefab do Canvas Temporizador na cena
            Instantiate(canvasTemporizadorPrefab);
        }
    }

    #region Animation WaitPoints
    void ModificarObjetos(float alpha, Vector3 scale)
    {
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            Color cor = spriteRenderers[i].color;
            cor.a = alpha;
            spriteRenderers[i].color = cor;

            WaitPoints[i].transform.localScale = scale;
        }
    }

    void ResetarObjetos()
    {
        ModificarObjetos(originalAlpha, originalScale);
    }
#endregion

#region Acecibility options
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

        //cam_Script.GetComponent<CamZoon>().sliderZoom(TypeZoom.value);
    }

    public void CloseAcessibility()
    {
        Canvas_Acessibility.SetActive(false);
    }

    void MostrarLegenda(string texto)
    {
        // exibir a legenda na interface
        Legenda.text = " ";
        Legenda.text = texto;

        // Obtém o tamanho preferido do texto
        Vector2 tamanhoTexto = new Vector2(Legenda.preferredWidth, Legenda.preferredHeight);

        // Ajusta o tamanho do painel conforme o texto e a margem
        painelLegenda.GetComponent<RectTransform>().sizeDelta = tamanhoTexto + new Vector2(margem, margem);

        Debug.Log("Legenda: " + texto); 
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

    public void StarMinigames()
    {
        LoadMinigames = true;
        SceneController.StartNextMinigame();
    }

    public void AlternarSons()
    {
        if (ButaoSon_ON.activeSelf)
        {
            // Se somOn está ativado, desativa ele e ativa somOff
            ButaoSon_ON.SetActive(false);
            ButaoSon_OFF.SetActive(true);

            // sons do jogo
            AudioListener.pause = true; // Pausa todos os sons do jogo
        }
        else
        {
            // Se somOff está ativado, desativa ele e ativa somOn
            ButaoSon_OFF.SetActive(false);
            ButaoSon_ON.SetActive(true);

            // sons do jogo
            AudioListener.pause = false; // Ativa todos os sons do jogo
        }
    }

    #endregion
}
