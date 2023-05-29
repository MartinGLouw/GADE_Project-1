using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject player; // reference to player game object
    public GameObject prefab; // prefab to spawn
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject Floor;
    public GameObject Pickup1;
    public GameObject Pickup2;
    public GameObject Pickup3;
    public float spawnDistance = 10f; // distance to spawn prefab in front of player
    public Vector3[] spawnPositions; // array of possible spawn positions
    public float spawnInterval = 4f; // time interval between spawns in seconds
    public float spawnIntervalForPickup = 18f;
    private float timeSinceLastSpawn; // time since last spawn
    private float PosX;
    private float PosXPickup;
    private float timeSinceLastSpawnPickup;
    private float timeSinceStart;
    public bool touched;

    public float FloorDistance = 150f;

    // Add a list to store the positions of other prefabs
    private readonly List<Vector3> otherPrefabPositions = new();

    public void Start()
    {
    }

    private void Update()
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
            if (timeSinceStart < 90f)
            {
                //setting the spawn position out of three possible positions
                var RandNum = Random.Range(1, 4);
                if (RandNum == 1) PosX = -5;
                if (RandNum == 2) PosX = 0;
                if (RandNum == 3) PosX = 5;
                var RandPreFab = Random.Range(1, 4);
                {
                    if (RandPreFab == 1)
                    {
                        // Calculate the position to spawn the prefab
                        var position = new Vector3(PosX, 0.6f, player.transform.position.z + spawnDistance);

                        // Spawn the prefab
                        Instantiate(prefab, position, Quaternion.identity);

                        // Update the list of other prefab positions
                        otherPrefabPositions.Add(position);

                        // Reset time since last spawn
                        timeSinceLastSpawn = 0f;
                    }

                    if (RandPreFab == 2)
                    {
                        // Calculate the position to spawn the prefab
                        var position = new Vector3(PosX, 1, player.transform.position.z + spawnDistance);

                        // Spawn the prefab
                        Instantiate(prefab3, position, Quaternion.identity);

                        // Update the list of other prefab positions
                        otherPrefabPositions.Add(position);

                        // Reset time since last spawn
                        timeSinceLastSpawn = 0f;
                    }
                    else if (RandPreFab == 3)
                    {
                        // Calculate the position to spawn the prefab
                        var position = new Vector3(PosX, 1, player.transform.position.z + spawnDistance);

                        // Spawn the prefab
                        Instantiate(prefab2, position, Quaternion.identity);

                        // Update the list of other prefab positions
                        otherPrefabPositions.Add(position);

                        // Reset time since last spawn
                        timeSinceLastSpawn = 0f;
                    }
                }
            }


            // Reset time since last spawn
            timeSinceLastSpawn = 0f;

            var RandNumPickup = Random.Range(1, 4);
            if (RandNumPickup == 1) PosXPickup = -5;
            if (RandNumPickup == 2) PosXPickup = 0;
            if (RandNumPickup == 3) PosXPickup = 5;
            if (timeSinceLastSpawnPickup >= spawnIntervalForPickup && timeSinceStart < 100f || timeSinceLastSpawnPickup >= spawnIntervalForPickup && timeSinceStart > 140f )
            {
                // Calculate the position to spawn the pickup prefab
                var position = new Vector3(PosXPickup, 1,
                    player.transform.position.z + spawnDistance);

                // Check if the pickup spawn position overlaps with another prefab's position
                var overlap = false;
                foreach (var otherPosition in otherPrefabPositions)
                    if (Vector3.Distance(position, otherPosition) < 1f)
                    {
                        overlap = true;
                        break;
                    }

                if (!overlap)
                {
                    // Randomly choose which pickup prefab to spawn
                    var pickupToSpawn = Random.Range(1, 4);
                    if (pickupToSpawn == 1)
                        Instantiate(Pickup1, position, Quaternion.identity);
                    else if (pickupToSpawn == 2)
                        Instantiate(Pickup2, position, Quaternion.identity);
                    else
                        Instantiate(Pickup3, position, Quaternion.identity);

                    // Reset time since last pickup spawn
                    timeSinceLastSpawnPickup = 0f;
                }
            }

            if (timeSinceStart > 140f)
            {
                //setting the spawn position out of three possible positions
                var RandNum = Random.Range(1, 4);
                if (RandNum == 1) PosX = -5;
                if (RandNum == 2) PosX = 0;
                if (RandNum == 3) PosX = 5;
                var RandPreFab = Random.Range(1, 4);
                {
                    if (RandPreFab == 1)
                    {
                        // Calculate the position to spawn the prefab
                        var position = new Vector3(PosX, 0.6f, player.transform.position.z + spawnDistance);
                        // Spawn the prefab
                        Instantiate(prefab, position, Quaternion.identity);
                        // Update the list of other prefab positions
                        otherPrefabPositions.Add(position);
                        // Reset time since last spawn
                        timeSinceLastSpawn = 0f;
                    }

                    if (RandPreFab == 2)
                    {
                        // Calculate the position to spawn the prefab
                        var position = new Vector3(PosX, 1, player.transform.position.z + spawnDistance);
                        // Spawn the prefab
                        Instantiate(prefab3, position: position, Quaternion.identity);
                        // Update the list of other prefab positions
                        otherPrefabPositions.Add(position);
                        // Reset time since last spawn
                        timeSinceLastSpawn = 0f;
                    }
                    else if (RandPreFab == 3)
                    {
                        // Calculate the position to spawn the prefab
                        var position = new Vector3(PosX, 1, player.transform.position.z + spawnDistance);
                        // Spawn the prefab
                        Instantiate(prefab2, position, Quaternion.identity);
                        // Update the list of other prefab positions
                        otherPrefabPositions.Add(position);
                        // Reset time since lastspawn
                        timeSinceLastSpawn = 0f;
                    }
                }
                // Reset time since last spawn
                timeSinceLastSpawn = 0f;
                var RandNumPickup2 = Random.Range(1, 4);

                if (RandNumPickup2 == 1)

                    PosXPickup = -5;

                if (RandNumPickup2 == 2)

                    PosXPickup = 0;

                if (RandNumPickup2 == 3)

                    PosXPickup = 5;

                if (timeSinceLastSpawnPickup >= spawnIntervalForPickup && timeSinceStart < 100f)

                {
                    // Calculate the position to spawn the pickup prefab
                    var position = new Vector3(PosXPickup, 1, player.transform.position.z + spawnDistance);
                    // Check if the pickup spawn position overlaps with another prefab's position
                    var overlap = false;
                    foreach (var otherPosition in otherPrefabPositions)
                        if (Vector3.Distance(position, otherPosition) < 1f)
                        {
                            overlap = true;

                            break;
                        }

                    if (!overlap)
                    {
                        // Randomly choose which pickup prefab to spawn
                        var pickupToSpawn = Random.Range(1, 4);
                        if (pickupToSpawn == 1)
                            Instantiate(Pickup1, position, Quaternion.identity);
                        else if (pickupToSpawn == 2)
                            Instantiate(Pickup2, position, Quaternion.identity);
                        else
                            Instantiate(Pickup3, position, Quaternion.identity);
                        // Reset time since last pickup spawn
                        timeSinceLastSpawnPickup = 0f;
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spawn") && !touched)
        {
            
            // Calculate the position to spawn the floor prefab
            var position = new Vector3(0, -0.6f, player.transform.position.z + FloorDistance);

            // Log the value of position

            // Spawn the floor prefab
            Instantiate(Floor, position, Quaternion.identity);
            touched = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spawn") && touched)
        {
            touched = false;
        }
    }
}