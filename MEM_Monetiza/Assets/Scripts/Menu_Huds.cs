using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Wilberforce;
using UnityEngine.SceneManagement;

public class Menu_Huds : MonoBehaviour
{
    //cada fase completa ganha 100 pontos
    public GameObject Canvas_Configura��es;

    //Acessibility
    public GameObject Canvas_Acessibility, Slade_Zoom;
    CamZoon cam_Script;

    //Colorblind dalto_Script;
    //int daltoType = 4;
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


    private void Awake()
    {
        Canvas_Acessibility.SetActive(false);
        Slade_Zoom.SetActive(false);
        Canvas_Configura��es.SetActive(false);
        painelLegenda.SetActive(false);
    }

    private void Start()
    {

        // Atribuir o componente Colorblind da c�mera principal � vari�vel dalto
        //dalto_Script = Camera.main.GetComponent<Colorblind>();

        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        //cam_Script.enabled = true;
        cam_Script = GetComponent<CamZoon>();

        // Armazenar os SpriteRenderers e valores originais
        spriteRenderers = new SpriteRenderer[WaitPoints.Length];
        for (int i = 0; i < WaitPoints.Length; i++)
        {
            spriteRenderers[i] = WaitPoints[i].GetComponent<SpriteRenderer>();
        }

        originalAlpha = spriteRenderers[0].color.a; // Supondo que todos t�m a mesma opacidade
        originalScale = WaitPoints[0].transform.localScale; // Supondo que todos t�m o mesmo tamanho

        // Modificar os objetos no in�cio
        ModificarObjetos(1.0f, originalScale * 1.2f); // Aumentar o tamanho e remover a transpar�ncia
        Invoke("ResetarObjetos", 5.0f); // Chamar a fun��o para resetar ap�s 5 segundos
    }

    private void Update()
    {
        /*// Legenda
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Obtemos o toque atual
            Touch touch = Input.GetTouch(0);

            // Converte a posi��o do toque para um raio na cena
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            // Se o raio atingir algum objeto na cena
            if (Physics.Raycast(ray, out hit))
            {
                painelLegenda.SetActive(true);
                // Verifica se o objeto atingido est� na lista de objetos
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
        }*/

        // Verifica se o Canvas de configura��es est� ativo
        if (Canvas_Configura��es.activeSelf)
        {
            // Se estiver ativo, desabilita o script da c�mera
            cam_Script.enabled = false;
        }
        else
        {
            // Se estiver desativado, habilita o script da c�mera
            cam_Script.enabled = true;
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
    public void ChangeDaltonismType() // M�todo chamado quando a op��o do Dropdown muda
    {
        // Verificar o �ndice selecionado no Dropdown
        int selectedIndex = TypeDaltonism.value;

        // Atribuir o tipo de daltonismo com base no �ndice selecionado
        Colorblind.Type = selectedIndex;
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

        // Obt�m o tamanho preferido do texto
        Vector2 tamanhoTexto = new Vector2(Legenda.preferredWidth, Legenda.preferredHeight);

        // Ajusta o tamanho do painel conforme o texto e a margem
        painelLegenda.GetComponent<RectTransform>().sizeDelta = tamanhoTexto + new Vector2(margem, margem);

        Debug.Log("Legenda: " + texto);
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

    public void StarMinigames()
    {
        Banco_Globais.StartFastGames = true;
    }

    public void AlternarSons()
    {
        if (ButaoSon_ON.activeSelf)
        {
            // Se somOn est� ativado, desativa ele e ativa somOff
            ButaoSon_ON.SetActive(false);
            ButaoSon_OFF.SetActive(true);

            // sons do jogo
            AudioListener.pause = true; // Pausa todos os sons do jogo
        }
        else
        {
            // Se somOff est� ativado, desativa ele e ativa somOn
            ButaoSon_OFF.SetActive(false);
            ButaoSon_ON.SetActive(true);

            // sons do jogo
            AudioListener.pause = false; // Ativa todos os sons do jogo
        }
    }
    #endregion
}
