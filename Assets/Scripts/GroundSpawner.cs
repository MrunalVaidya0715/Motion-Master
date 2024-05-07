using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // Reference to the ground prefab to be spawned
    public float spawnInterval = 5.0f; // Adjust the interval between ground spawns
    public float zOffset = 150.0f; // Adjust the distance between the spawned grounds along the Z-axis
    private bool spawning = true;

    void Start()
    {
        StartCoroutine(SpawnGround());
    }

    IEnumerator SpawnGround()
    {
        while (spawning)
        {
            // Spawn the first ground at the current position
            GameObject newGround = Instantiate(groundPrefab, transform.position, transform.rotation);

            // Move to the next spawn position along the Z-axis
            Vector3 nextSpawnPosition = transform.position + Vector3.forward * zOffset;

            // Spawn the second ground at the next position
            GameObject newGround2 = Instantiate(groundPrefab, nextSpawnPosition, transform.rotation);

            // Wait for the next interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
