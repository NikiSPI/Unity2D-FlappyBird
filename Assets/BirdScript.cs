using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public bool birdIsAlive = true;

    public float movingSpeed;
    public float speedUpClock, speedUpAmount;
    private float speedUpTimer = 0;

    public GameObject pipeSpawner;
    public GameObject cloudSpawner;
    private Vector2 savedVelocity;
    public bool gameIsPaused = false;

    public AudioSource flapAS;
    public GameObject wing;
    public GameObject flappedWing;
    public float flapStrength;
    public float flapDuration;
    private float flapTimer = 0;
    private float flapTimerAdd = 0;
    public float rotationStrength;

    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        SpeedUpCheck();

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive && !gameIsPaused)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;

            SwapWings(false);
            flapTimerAdd = 1;

            PlayFlap();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && birdIsAlive)
        {
            if (!gameIsPaused)
            {
                OnPauseGame();
                gameIsPaused = true;
            }
            else
            {
                OnResumeGame();
            }
        }

        flapTimer += Time.deltaTime * flapTimerAdd;
        if (flapTimer >= flapDuration)
        {
            SwapWings(true);
            flapTimerAdd = 0;
            flapTimer = 0;
        }

        if (!gameIsPaused)
        {
            SetRotation();
        }

    }

    private void SpeedUpCheck()
    {
        speedUpTimer += Time.deltaTime;

        if(speedUpTimer >= speedUpClock)
        {
            speedUpTimer = 0;

            movingSpeed += speedUpAmount;
        }
    }

    public void OnPauseGame()
    {
        pipeSpawner.SetActive(false);
        cloudSpawner.SetActive(false);

        savedVelocity = myRigidbody.velocity;

        myRigidbody.velocity = new Vector2(0, 0);
        myRigidbody.bodyType = RigidbodyType2D.Kinematic;

        logic.gamePause(true);
    }

    public void OnResumeGame()
    {
        logic.gamePause(false);

        pipeSpawner.SetActive(true);
        cloudSpawner.SetActive(true);

        myRigidbody.bodyType = RigidbodyType2D.Dynamic;

        gameIsPaused = false;

        myRigidbody.velocity = savedVelocity;
    }

    private void SwapWings(bool fw)
    {
        wing.SetActive(fw);
        flappedWing.SetActive(!fw);
    }

    public void PlayFlap()
    {
        flapAS.Play();
    }
   
    private void SetRotation()
    {
        transform.rotation = Quaternion.AngleAxis(myRigidbody.velocity.y * rotationStrength, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

}
