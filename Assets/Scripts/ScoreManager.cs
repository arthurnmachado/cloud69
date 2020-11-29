using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText;
    public int valorAcerto = 100;
    public int valorErrou = -100;
    private int score;

    void Awake()
    {

        if (Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    public void Errou()
    {
        if (Instance is null)
            return;
        score += valorErrou;
        score = score < 0 ? 0 : score;
        scoreText.text = "Pontuação: " + score.ToString();
        
    }

    public void Acertou()
    {
        if (Instance is null)
            return;
        score += valorAcerto;
        scoreText.text = "Pontuação: " + score.ToString();
    }

    void OnDestroy()
    {
        Instance = null;
    }
}
