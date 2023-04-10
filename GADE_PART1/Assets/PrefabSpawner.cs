using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject player; // reference to player game object
    public GameObject prefab; // prefab to spawn
    public float spawnDistance = 10f; // distance to spawn prefab in front of player
    public Vector3[] spawnPositions; // array of possible spawn positions
    public float spawnInterval = 4f; // time interval between spawns in seconds
    private float timeSinceLastSpawn = 0f; // time since last spawn
    private float PosX;

    void Update()
    {
        // Update time since last spawn
        timeSinceLastSpawn += Time.deltaTime;

        // Check if it's time to spawn a new prefab
        if (timeSinceLastSpawn >= spawnInterval)
        {
            var RandNum = Random.Range(1, 4);
            if (RandNum == 1)
            {
                PosX = -5;
            }
            if (RandNum == 2)
            {
                PosX = 0;
            }
            if (RandNum == 3)
            {
                PosX = 5;
            }

            // Calculate the position to spawn the prefab
            Vector3 position = new Vector3(PosX, player.transform.position.y, player.transform.position.z + spawnDistance);

            // Spawn the prefab
            Instantiate(prefab, position, Quaternion.identity);

            // Reset time since last spawn
            timeSinceLastSpawn = 0f;
        }
    }
}