using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject player; // reference to player game object
    public GameObject prefab; // prefab to spawn
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject Floor;
    public GameObject Pickup;
    public float spawnDistance = 10f; // distance to spawn prefab in front of player
    public Vector3[] spawnPositions; // array of possible spawn positions
    public float spawnInterval = 4f; // time interval between spawns in seconds
    public float spawnIntervalForPickup = 18f;
    private float timeSinceLastSpawn = 0f; // time since last spawn
    private float PosX;
    private float PosXPickup;
    private float timeSinceLastSpawnPickup = 0f;
    private float timeSinceStart = 0f;

    void Update()
    {
        // Update time since start
        timeSinceStart += Time.deltaTime;

        // Update time since last spawn for pickup
        timeSinceLastSpawnPickup += Time.deltaTime;

        // Update time since last spawn
        timeSinceLastSpawn += Time.deltaTime;

        // Check if it's time to spawn a new prefab
        if (timeSinceLastSpawn >= spawnInterval)
        {
            if (timeSinceStart < 5f)
            {
                //setting the spawn position out of three possible positions
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
                var RandPreFab = Random.Range(1, 4);
                {
                    if (RandPreFab == 1)
                    {
                        // Calculate the position to spawn the prefab
                        Vector3 position = new Vector3(PosX, 0.6f, player.transform.position.z + spawnDistance);

                        // Spawn the prefab
                        Instantiate(prefab, position, Quaternion.identity);

                        // Reset time since last spawn
                        timeSinceLastSpawn = 0f;
                    }

                    if (RandPreFab == 2)
                    {
                        // Calculate the position to spawn the prefab
                        Vector3 position = new Vector3(PosX, 1, player.transform.position.z + spawnDistance);

                        // Spawn the prefab
                        Instantiate(prefab3, position, Quaternion.identity);

                        // Reset time since last spawn
                        timeSinceLastSpawn = 0f; 
                    }
                    else if (RandPreFab == 3)
                    {
                        // Calculate the position to spawn the prefab
                        Vector3 position = new Vector3(PosX, 1, player.transform.position.z + spawnDistance);

                        // Spawn the prefab
                        Instantiate(prefab2, position, Quaternion.identity);

                        // Reset time since last spawn
                        timeSinceLastSpawn = 0f; 
                    }
                }
            }

            // Calculate the position to spawn the floor prefab
            Vector3 position2 = new Vector3(0, -1,
            player.transform.position.z + spawnDistance);

            // Spawn the floor prefab
            Instantiate(Floor, position2, Quaternion.identity);

            // Reset time since last spawn
            timeSinceLastSpawn = 0f;

            var RandNumPickup = Random.Range(1, 4);
            if (RandNumPickup == 1)
            {
                PosXPickup = -5;
            }
            if (RandNumPickup == 2)
            {
                PosXPickup = 0;
            }
            if (RandNumPickup == 3)
            {
                PosXPickup = 5;
            }
            if (timeSinceLastSpawnPickup >= spawnIntervalForPickup && timeSinceStart < 5f)
            {
                // Calculate the position to spawn the pickup prefab
                Vector3 position = new Vector3(PosXPickup, 1,
                player.transform.position.z + spawnDistance);

                // Spawn the pickup prefab
                Instantiate(Pickup, position, Quaternion.identity);

                // Reset time since last pickup spawn
                timeSinceLastSpawnPickup = 0f; 
                
            }
        }
    }
}
