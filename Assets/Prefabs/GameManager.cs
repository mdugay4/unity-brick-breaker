using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Lives;
    public int Score;
    public Text livesText;
    public Text scoreText;
    public Text grayCount;
    public Text redCount;
    public Text finalScoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfGrayBricks;
    public int numberOfRedBricks;
    public int numberOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + Lives;
        scoreText.text = "Score: " + Score;
        numberOfGrayBricks = GameObject.FindGameObjectsWithTag("Gray Brick").Length;
        numberOfRedBricks = GameObject.FindGameObjectsWithTag("Red Brick").Length;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Gray Brick").Length + GameObject.FindGameObjectsWithTag("Red Brick").Length;
        grayCount.text = "Gray Bricks " + numberOfGrayBricks;
        redCount.text = "Red Bricks: " + numberOfRedBricks;
    }

    // Update is called once per frame
    void Update()
    {
        numberOfGrayBricks = GameObject.FindGameObjectsWithTag("Gray Brick").Length;
        numberOfRedBricks = GameObject.FindGameObjectsWithTag("Red Brick").Length;
        grayCount.text = "Gray Bricks " + numberOfGrayBricks;
        redCount.text = "Red Bricks: " + numberOfRedBricks;
    }

    public void UpdateLives(int changeInLives)
    {
        Lives += changeInLives;
        if(Lives <= 0)
        {
            Lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + Lives;
    }

    public void UpdateScore(int points)
    {
        if (2 * numberOfRedBricks <= numberOfGrayBricks)
        {
            Score += points;
            scoreText.text = "Score: " + Score;
        }
        else
        {
            points = 1;
            Score += points;
            scoreText.text = "Score: " + Score;
        }
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            GameOver();
        }  
    }

    public void UpdateNumberOfGrayBricks()
    {
        numberOfGrayBricks--;
    }

    public void UpdateNumberOfRedBricks()
    {
        numberOfRedBricks--;
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        int finalScore = PlayerPrefs.GetInt("HIGHSCORE");
        if(Score > finalScore || numberOfBricks == 0)
        {
            PlayerPrefs.SetInt("HIGHSCORE", Score);
            finalScoreText.text = "New High Score!: " + Score + "\n" + "You Win!";
        }
        else
        {
            finalScoreText.text = "High Score: " + finalScore + "\n" + "You Lose!";
        }

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
