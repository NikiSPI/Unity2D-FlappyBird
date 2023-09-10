using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    public AudioSource advanceAS;
    public int advanceOnPipeNum = 5;
    private int counter = 0;


    [ContextMenu("Increase Score")]
    public void addScore(int addScore)
    {
        playerScore += addScore;
        scoreText.text = playerScore.ToString();

        PerformSoundCount();
        
    }

    private void PerformSoundCount()
    {
        counter++;
        if (counter >= advanceOnPipeNum)
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
        gameOverScreen.SetActive(true);
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
