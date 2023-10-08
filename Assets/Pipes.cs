using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript: MonoBehaviour
{
    public float deadZone = -45;
    private BirdScript birdScript;
    public AudioSource hitAS;


    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    void Update()
    {
        if (birdScript.birdIsAlive && !birdScript.gameIsPaused)
        {
            transform.position += (Vector3.left * birdScript.movingSpeed) * Time.deltaTime;
        }

        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

    public void PlayHit()
    {
        hitAS.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayHit();
        Debug.Log("Colided with a Pipe");
    }
}
