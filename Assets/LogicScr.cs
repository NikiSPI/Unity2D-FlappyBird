using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    public void addScore(int addScore)
    {
        playerScore += addScore;
        scoreText.text = playerScore.ToString();
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
