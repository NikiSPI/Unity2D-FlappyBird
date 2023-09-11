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
    public GameObject gameOverScreen;

    public AudioSource advanceAS;
    public int advanceOnPipeNum = 5;
    private int counter = 0;

    private StreamReader highScoreFileReader = new StreamReader("Assets\\unitytut-HighScore.txt");
    private int highScore;
    bool newHighScore = false;

    private void Start()
    {
        highScore = Convert.ToInt32(highScoreFileReader.ReadLine());
    }

    public void addScore(int addScore)
    {
        playerScore += addScore;
        scoreText.text = playerScore.ToString();

        if(playerScore > highScore && !newHighScore)
        {
            newHighScore = true;
        }

        PerformSoundCount();
        
    }

    private void PerformSoundCount()
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


    public void gameOver()
    {
        if (newHighScore)
        {
            highScore = playerScore;
            saveHighScore(highScore);
        }

        gameOverScreen.SetActive(true);
    }

    private void saveHighScore(int intToSave)
    {
        highScoreFileReader.Dispose();

        StreamWriter highScoreFileWriter = new StreamWriter("Assets\\unitytut-HighScore.txt", false);
        highScoreFileWriter.WriteLine(intToSave);
        highScoreFileWriter.Dispose();

        Debug.Log("Successfully saved a new High Score: " + intToSave);
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
