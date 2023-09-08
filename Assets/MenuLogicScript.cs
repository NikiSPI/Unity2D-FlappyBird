using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogicScript : MonoBehaviour
{

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
