using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    public GameObject scoreText;
    public GameObject lifeText;
    private int playerLives = 5;
    private int playerScore = 0;
    public GameObject gameOverText;

    void Start()
    {
        gameOverText.SetActive(false);
        UpdateScore();
    }

    public void AddScore(int points)
    {
        playerScore += points;
        UpdateScore();
    }

    public void RemoveLife(int points)
    {
        playerLives -= points;
        UpdateScore();
    }

    void UpdateScore()
    {
        Text scoreTextB = scoreText.GetComponent<Text>();
        Text lifeTextB = lifeText.GetComponent<Text>();
        lifeTextB.text = "Lives: " + playerLives;

        if (playerLives > 0)
        {
            scoreTextB.text = "Score: " + playerScore;
            lifeTextB.text = "Lives: " + playerLives;
        }
        else if (playerLives <= 0)
        {
            lifeTextB.text = "Lives: 0";
            gameOverText.SetActive(true);
        }

    }
}