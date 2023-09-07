using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate = 2;
    private float timer = 0;

    private int randomYPoint;
    public float YOffset = 20;
    public float cloudDist = 2;

    public float deadZone = -40;
    public float cloudMoveSpeed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        float defaultXDist = spawnRate * cloudMoveSpeed;

        for(float i = (transform.position.x - deadZone) / defaultXDist; i > 0; i--)
        {

            SpawnCloud(i * defaultXDist + deadZone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnCloud(transform.position.x);
            timer = 0;
        }
    }
    private void SpawnCloud(float Xposition)
    {
        float lowestPoint = transform.position.y - YOffset;
        float highestPoint = transform.position.y + YOffset;
        int tempRand;

        do
        { 
            tempRand = (int)Random.Range(lowestPoint, highestPoint); 
        }
        while (tempRand >= randomYPoint - cloudDist && tempRand <= randomYPoint + cloudDist);

        randomYPoint = tempRand;

        Instantiate(cloud, new Vector3(Xposition, randomYPoint, 0), transform.rotation);

    }
}
