using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllScore : MonoBehaviour
{
    public GameObject[] torcedoresOne, torcedoresTwo, torcedoresTree;
    public float tempoExibicao = 2f;

    public Text scoreText;
    public int score = 0;

    public int life = 3;

    private void Start()
    {
        StartCoroutine(torcedores1());
        StartCoroutine(torcedores2());
        StartCoroutine(torcedores3());
    }

    public IEnumerator torcedores1()
    {
        if(life == 2)
        {
            torcedoresOne[3].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {     
            torcedoresOne[0].GetComponent<SpriteRenderer>().enabled = true;
            torcedoresOne[1].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresOne[2].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresOne[3].GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(tempoExibicao);
            torcedoresOne[0].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresOne[1].GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(tempoExibicao);
            torcedoresOne[1].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresOne[2].GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(tempoExibicao);
            torcedoresOne[2].GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(torcedores1());
        }
        
    }

    public IEnumerator torcedores2()
    {
        if(life == 1)
        {
            torcedoresTwo[3].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            torcedoresTwo[0].GetComponent<SpriteRenderer>().enabled = true;
            torcedoresTwo[1].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresTwo[2].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresTwo[3].GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(tempoExibicao);
            torcedoresTwo[0].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresTwo[1].GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(tempoExibicao);
            torcedoresTwo[1].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresTwo[2].GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(tempoExibicao);
            torcedoresTwo[2].GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(torcedores2());
        }
    }

    public IEnumerator torcedores3()
    {
        if(life == 0)
        {
            torcedoresTree[3].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            torcedoresTree[0].GetComponent<SpriteRenderer>().enabled = true;
            torcedoresTree[1].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresTree[2].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresTree[3].GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(tempoExibicao);
            torcedoresTree[0].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresTree[1].GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(tempoExibicao);
            torcedoresTree[1].GetComponent<SpriteRenderer>().enabled = false;
            torcedoresTree[2].GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(tempoExibicao);
            torcedoresTree[2].GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(torcedores3());
        } 
    }
}
