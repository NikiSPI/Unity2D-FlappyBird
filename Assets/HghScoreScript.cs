using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HghScoreScript : MonoBehaviour
{
    public Text highScoreText;

    private void Start()
    {
        StreamReader sr = new StreamReader("Assets\\unitytut-HighScore.txt");
        highScoreText.text = sr.ReadLine();
        sr.Dispose();
    }

    void Update()
    {
        
    }
}
