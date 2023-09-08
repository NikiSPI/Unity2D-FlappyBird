using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCloudScript : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float deadZone = -45;
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
