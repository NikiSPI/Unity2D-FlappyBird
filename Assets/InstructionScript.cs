using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor.PackageManager.UI;
using UnityEngine.Analytics;
using Unity.VisualScripting;

public class InstructionScript : MonoBehaviour
{
    public Text instructionsTextBox;
    public string[] instructions;
    private int currentInstruction = 0;

    public float displayTime, fadeTime, waitTime;
    private float timer = 0;
    private bool instructionsSwitching = true, fadeInRunning = false, textStill = false, fadeOutRunning = false;
    Color dfltFontColor, nullColor;


    void Start()
    {
        dfltFontColor = instructionsTextBox.color;
    }
    void Update()
    {

        if (instructionsSwitching)
        {
            if(timer == 0)
            {
                if(currentInstruction >= instructions.Length)
                {
                    instructionsSwitching = false;
                }
                else
                {
                    PerformFade(1);

                    instructionsTextBox.text = instructions[currentInstruction];
                    currentInstruction++;
                }                
            }

            if(timer < waitTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                PeriodEnd(true);
            }
        }

        if (textStill) 
        { 
            if (timer < displayTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                PeriodEnd(false, false, true);
            }
        }        

        else if (fadeInRunning)
        {
            if(timer < fadeTime)
            {
                timer += Time.deltaTime;
                PerformFade(1 - timer / fadeTime);
            }
            else
            {
                PeriodEnd(false, true);
            }

        }        

        else if (fadeOutRunning)
        {
            if(timer < fadeTime)
            {
                timer += Time.deltaTime;
                PerformFade(timer / fadeTime);
            }
            else
            {
                PeriodEnd(false, false, false, true);
            }
        }
        
        }
    private void PerformFade(float levelOfTransparency)
    {
        instructionsTextBox.color = Color.Lerp(dfltFontColor, nullColor, levelOfTransparency);
    }

    private void PeriodEnd(bool IN = false, bool STILL = false, bool OUT = false, bool WAIT = false)
    {
        fadeInRunning = IN;
        textStill = STILL;
        fadeOutRunning = OUT;
        instructionsSwitching = WAIT;

        timer = 0;
    }

}
