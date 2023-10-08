using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    public Text highScoreText;
    private StreamReader sr = new StreamReader("Assets\\unitytut-HighScore.txt");
    void Start()
    {
        highScoreText.text = sr.ReadLine();
        sr.Dispose();
    }
    void Update()
    {
        
    }
}
