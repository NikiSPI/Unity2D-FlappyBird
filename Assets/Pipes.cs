using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript: MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    private BirdScript birdScript;
    public AudioSource hitAS;

    // Start is called before the first frame update
    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdScript.birdIsAlive)
        {
            transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
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
