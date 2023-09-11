using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float deadZone = -45;
    private BirdScript birdScript;

    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdScript.birdIsAlive && !birdScript.gameIsPaused)
        {
            transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
