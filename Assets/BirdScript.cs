using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public bool birdIsAlive = true;

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
    private float timerAdd = 0;
    public float rotationStrength;

    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive && !gameIsPaused)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;

            SwapWings(false);
            timerAdd = 1;

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
                gameIsPaused = false;
            }
        }

        flapTimer += Time.deltaTime * timerAdd;
        if (flapTimer >= flapDuration)
        {
            SwapWings(true);
            timerAdd = 0;
            flapTimer = 0;
        }

        if (!gameIsPaused)
        {
            SetRotation();
        }

    }

    private void OnPauseGame()
    {
        pipeSpawner.SetActive(false);
        cloudSpawner.SetActive(false);

        savedVelocity = myRigidbody.velocity;

        myRigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void OnResumeGame()
    {
        pipeSpawner.SetActive(true);
        cloudSpawner.SetActive(true);

        myRigidbody.bodyType = RigidbodyType2D.Dynamic;

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
