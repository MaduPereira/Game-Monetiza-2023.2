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
            controllScore.enabled = true;
        }


        if (SceneManager.GetActiveScene().name != "Game")
        {
            Canvas_Tutorial = GameObject.Find("Canvas_Tutorial");
            Canvas_Tutorial.SetActive(true);
        }

    }

    private void Update()
    {
        SceneController = GetComponent<ControladoDeScene>();

        controllScore = GetComponent<ControllScore>();

        if(StartFastGames == true)
        {
            LoadMinigames = true;
            SceneController.StartNextMinigame();
            StartFastGames = false;
        }

        if (LoadMinigames == true)
        {
            Debug.Log("loadGame");
            StartCoroutine(TimeTutorial());
            LoadMinigames = false;
        }

        if(FinishGame == true)
        {
            Debug.Log("Acabou a fase");
            FinishGame = false;

            if (SitPerdeu == true)
            {
                Debug.Log("fase perdida");
                ControllScore.life--;
            }

            startFase = false;
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
        yield return new WaitForSeconds(0.5f);

        if(Canvas_Tutorial != null)
        {
            Canvas_Tutorial.SetActive(false);
        }
        else
        {
            Canvas_Tutorial = GameObject.Find("Canvas_Tutorial");
            Canvas_Tutorial.SetActive(false);
        }
        Debug.Log("desativa");
        // Verificar se o objeto Canvas Temporizador está presente na cena
        GameObject canvasTemporizador = GameObject.Find("Canvas.Time(Clone)");

        if (canvasTemporizador == null)
        {
            // Se não estiver presente, instanciar o prefab do Canvas Temporizador
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
