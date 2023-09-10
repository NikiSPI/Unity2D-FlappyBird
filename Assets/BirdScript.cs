using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public AudioSource flapAS;
    public bool birdIsAlive = true;

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;

            SwapWings(false);
            timerAdd = 1;

            PlayFlap();
        }

        flapTimer += Time.deltaTime * timerAdd;
        if (flapTimer >= flapDuration)
        {
            SwapWings(true);
            timerAdd = 0;
            flapTimer = 0;
        }

        SetRotation();

    }

    private void SwapWings(bool fw)
    {
        wing.SetActive(fw);
        flappedWing.SetActive(!fw);
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.AngleAxis(myRigidbody.velocity.y * rotationStrength, Vector3.forward);
    }

    public void PlayFlap()
    {
        flapAS.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        logic.gameOver();
    }
}
