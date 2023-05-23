using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObstaclesSpawn : MonoBehaviour
{
    public GameObject player; // reference to player game object
    public GameObject obstaclePrefab; // obstacle prefab to spawn
    public float spawnDistance = 10f; // distance to spawn obstacle in front of player
    public float spawnInterval = 1f; // time interval between obstacle spawns in seconds
    private float timeSinceLastSpawn = 0f; // time since last obstacle spawn
    public float timeSinceStart = 0f;
    public float spawnDelay = 5f;
    private float[] positions = new float[] { -5, 0, 5 };
    public float spawnIntervalDecreaseRate = 0.1f;
    public float minSpawnInterval = 0.1f;

    private float timeSinceObstacleSpawnStart = 0f; // variable to keep track of time since obstacle spawning started

    void Update()
    {
        timeSinceStart += Time.deltaTime;

        if (timeSinceStart >= spawnDelay)
        {
            // Increase timeSinceObstacleSpawnStart
            timeSinceObstacleSpawnStart += Time.deltaTime;

            // Stop obstacle spawning after 40 seconds have passed
            if (timeSinceObstacleSpawnStart < 40f)
            {
                // Update time since last obstacle spawn
                timeSinceLastSpawn += Time.deltaTime;

                // Check if it's time to spawn new obstacles
                if (timeSinceLastSpawn >= spawnInterval)
                {
                    // Shuffle the positions array
                    for (int i = 0; i < positions.Length; i++)
                    {
                        int rnd = Random.Range(0, positions.Length);
                        float temp = positions[rnd];
                        positions[rnd] = positions[i];
                        positions[i] = temp;
                    }

                    // Spawn obstacles at the first two positions in the shuffled array
                    for (int i = 0; i < 2; i++)
                    {
                        Vector3 position = new Vector3(positions[i], 1,
                            player.transform.position.z + spawnDistance);

                        Instantiate(obstaclePrefab, position, Quaternion.identity);
                    }

                    // Reset time since last obstacle spawn
                    timeSinceLastSpawn = 0f;
                }

                // Gradually decrease the spawn interval over time
                spawnInterval -= spawnIntervalDecreaseRate * Time.deltaTime;
                spawnInterval = Mathf.Max(spawnInterval, minSpawnInterval);
            }
        }
    }

}
