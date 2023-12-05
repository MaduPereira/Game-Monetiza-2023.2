using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Banco_Globais : MonoBehaviour
{
    //games
    ControladoDeScene SceneController;

    public GameObject canvasTemporizadorPrefab; // Prefab do Canvas Temporizador
    public static bool LoadMinigames = false;

    ControllScore controllScore;

    public static bool SitPerdeu = false;
    public static bool FinishGame = false;

    private static Banco_Globais instance;

    public GameObject Canvas_Tutorial;

    public static bool startFase = false;

    public static bool GGOVER = false;

    public static bool StartFastGames = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneController = GetComponent<ControladoDeScene>();

        controllScore = GetComponent<ControllScore>();

        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        if (SceneManager.GetActiveScene().name == "Score")
        {
            controllScore.enabled = false;
        } 
    }

    private void Update()
    {
        SceneController = GetComponent<ControladoDeScene>();

        controllScore = GetComponent<ControllScore>();

        if (SceneManager.GetActiveScene().name != "Game")
        {
            Canvas_Tutorial = GameObject.Find("Canvas_Tutorial");
            Canvas_Tutorial.SetActive(true);
        }

        if(StartFastGames == true)
        {
            LoadMinigames = true;
            SceneController.StartNextMinigame();
            StartFastGames = false;
        }

        if (LoadMinigames == true)
        {
            StartCoroutine(TimeTutorial());
        }

        if(FinishGame == true)
        {
            Debug.Log("Acabou a fase");
            if (SitPerdeu == true)
            {
                Debug.Log("fase perdida");
                ControllScore.life--;
            }

            startFase = false;
            LoadMinigames = false;
            StartCoroutine(timeFinish());
        }

        if(GGOVER == true)
        {
            ControllScore.life = 3;
            SceneManager.LoadScene("Game");
        }
    }

    IEnumerator timeFinish()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Score");
    }

    IEnumerator TimeTutorial()
    {
        yield return new WaitForSeconds(2);
        Canvas_Tutorial.SetActive(false);
        Debug.Log("desativa");
        // Verificar se o objeto Canvas Temporizador est� presente na cena
        GameObject canvasTemporizador = GameObject.Find("Canvas.Time(Clone)");

        if (canvasTemporizador == null)
        {
            // Se n�o estiver presente, instanciar o prefab do Canvas Temporizador
            InstantiateCanvasTemporizador();
        }

        startFase = true;
        LoadMinigames = false;
    }

    void InstantiateCanvasTemporizador()
    {
        Instantiate(canvasTemporizadorPrefab);
    }
}
