using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isRunning)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if(transform.position.x < -10)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
