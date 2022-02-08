using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    public GameObject scoreText;
    private int playerScore = 0;
    public GameObject gameOverTextB;
    public GameObject gameOverTextF;
    public GameObject winTextB;
    public GameObject winTextF;

    void Start()
    {
        gameOverTextF.SetActive(false);
        gameOverTextB.SetActive(false);
        winTextF.SetActive(false);
        winTextB.SetActive(false);
        UpdateScore();
    }

    public void AddScore(int points)
    {
        playerScore += points;
        UpdateScore();
    }

    void UpdateScore()
    {
        Text scoreTextB = scoreText.GetComponent<Text>();

        scoreTextB.text = "Score: " + playerScore;
        if(playerScore >= 5)
        {
            scoreTextB.text = "Score: 5";
            winTextF.SetActive(true);
            winTextB.SetActive(true);
        }
    }
}