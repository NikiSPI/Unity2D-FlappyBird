using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float YOffset = 10;

    public float speedUpClock, speedUpAmount;
    private float speedUpTimer = 0;

    void Start()
    {
        timer = spawnRate;
    }

    void Update()
    {
        SpeedUpCheck();

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }

    private void SpeedUpCheck()
    {
        speedUpTimer += Time.deltaTime;

        if (speedUpTimer >= speedUpClock)
        {
            speedUpTimer = 0;

            spawnRate -= speedUpAmount * spawnRate;
        }
    }

    private void SpawnPipe()
    {
        float lowestPoint = transform.position.y - YOffset;
        float highestPoint = transform.position.y + YOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

    }
}
