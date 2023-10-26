using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject instructions;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject HighScorePanel;
    public Text highScoreText;

    public AudioSource advanceAS;
    public int advanceOnPipeNum = 5;
    private int counter = 0;

    private int highScore;
    bool newHighScore = false;

    private void Start()
    {
        StreamReader highScoreFileReader = new StreamReader("Assets\\unitytut-HighScore.txt");
        highScore = Convert.ToInt32(highScoreFileReader.ReadLine());
        highScoreFileReader.Dispose();
    }

    public void AddScore(int addScore)
    {
        playerScore += addScore;
        scoreText.text = playerScore.ToString();

        if(playerScore == highScore + 1)
        {
            newHighScore = true;
        }

        PerformAdvanceCount();
        
    }

    private void PerformAdvanceCount()
    {
        counter++;
        if (counter == advanceOnPipeNum)
        {
            PlayAdvance();
            Debug.Log("You Advanced "+ advanceOnPipeNum +" More Levels");

            counter = 0;
        }
    }

    private void PlayAdvance()
    {
        advanceAS.Play();
    }


    public void GamePause(bool isGamePaused)
    {
        pauseMenu.SetActive(isGamePaused);
    }

    public void GameOver()
    {
        CheckForHighScore();

        instructions.SetActive(false);
        gameOverMenu.SetActive(true);
        HighScorePanel.SetActive(true);
    }
    

    public void CheckForHighScore()
    {
        if (newHighScore)
        {
            highScore = playerScore;
            saveHighScore();
        }
    }

    private void saveHighScore() 
    {
        StreamWriter highScoreFileWriter = new StreamWriter("Assets\\unitytut-highScore.txt", false);
        highScoreFileWriter.WriteLine(highScore);
        highScoreFileWriter.Dispose();

        Debug.Log("Successfully saved a new High Score: " + highScore);
    }

    public void restartGame()
    {
        Debug.Log("Restarting the game...");
        SceneManager.LoadScene("GameScene");
    }

    public void exitGame()
    {
        Debug.Log("Going back to the main menu...");
        SceneManager.LoadScene("MainMenuScene");
    }
}
