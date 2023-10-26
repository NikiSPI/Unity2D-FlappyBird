using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLogicScript : MonoBehaviour
{    
    public Text highScoreText;

    private void Start()
    {
        StreamReader sr = new StreamReader("Assets\\unitytut-HighScore.txt");
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
