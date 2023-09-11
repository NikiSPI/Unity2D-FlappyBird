using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLogicScript : MonoBehaviour
{
    private StreamReader sr = new StreamReader("Assets\\unitytut-HighScore.txt");
    public Text highScoreText;

    private void Start()
    {
        highScoreText.text = sr.ReadLine();
        sr.Dispose();
    }

    public void startGame()
    {
        Debug.Log("Starting the game...");
        SceneManager.LoadScene("GameScene");
    }

    public void quitApp()
    {
        Debug.Log("Quiting the game...");
        Application.Quit(0);
    }

}
