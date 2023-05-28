using System.Collections;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject prefab;
    public Transform player;
    public float spawnDelay = 50f;
    public float riseSpeed = 1f;
    public float maxHeight = 5f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(spawnDelay);

        Vector3 spawnPosition = player.position + player.forward;
        GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);
        Destroy(instance, 50f); // destroy the boss after 30 seconds

        while (instance.transform.position.y < maxHeight)
        {
            instance.transform.position += Vector3.up * riseSpeed * Time.deltaTime;
            instance.transform.position = new Vector3(0, instance.transform.position.y, player.position.z + 70);
            yield return null;
        }

        while (true)
        {
            instance.transform.position = new Vector3(0, instance.transform.position.y, player.position.z + 70);
            yield return null;
        }
    }
}