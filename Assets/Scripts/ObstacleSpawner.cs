using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;

    public bool spawning;

    public float maxWaitTime = 2f;

    Vector3 spawnPos = new(10, 0, 0);

    private void OnEnable()
    {
        BirdController.onBirdDie += StopSpawning;
    }

    private void OnDisable()
    {
        BirdController.onBirdDie -= StopSpawning;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawning = true;

        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObstacles()
    {
        while (spawning)
        {
            float offset = Random.Range(-3f, 3f);
            spawnPos.y = offset; 
            GameObject go = Instantiate(obstacle, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(1f, maxWaitTime));
        }
    }

    void StopSpawning()
    {
        StopAllCoroutines();
    }
}
