using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    // The spawning surface where you want to spawn the objects
    [SerializeField] private BoxCollider spawningSurface;
    // The object that you want to spawn
    [SerializeField] private Transform objectToSpawn;
    // This is if there are multiple different objects you want to spawn
    [SerializeField] private Transform[] objectsToSpawn;
    // Required floats for the spawner to work correctly
    private float objectSpawnX, objectSpawnZ, previousobjectSpawnX, previousobjectSpawnZ, spawnPosDifferenceX, spawnPosDifferenceZ;
    // This is the delay in seconds for the object spawning timer. 1 Second by default
    private float spawnDelay = 1f;

    void Start()
    {
        // This starts the random spawner for just one object
        StartCoroutine(SpawnObjectRandomly());
        // This starts the random spawner for an array of objects
        // StartCoroutine(SpawnObjectsRandomly()); 
    }

    IEnumerator SpawnObjectRandomly()
    {
        while(true)
        {
            objectSpawnX = Random.Range(spawningSurface.bounds.min.x, spawningSurface.bounds.max.x);
            objectSpawnZ = Random.Range(spawningSurface.bounds.min.z, spawningSurface.bounds.max.z);
            if (previousobjectSpawnX != 0f && previousobjectSpawnZ != 0f)
            {
                spawnPosDifferenceX = Mathf.Abs(objectSpawnX - previousobjectSpawnX);
                spawnPosDifferenceZ = Mathf.Abs(objectSpawnZ - previousobjectSpawnZ);
                while (spawnPosDifferenceX < 4f)
                {
                    objectSpawnX = Random.Range(spawningSurface.bounds.min.x, spawningSurface.bounds.max.x);
                    objectSpawnZ = Random.Range(spawningSurface.bounds.min.z, spawningSurface.bounds.max.z);
                    spawnPosDifferenceX = Mathf.Abs(objectSpawnX - previousobjectSpawnX);
                    spawnPosDifferenceZ = Mathf.Abs(objectSpawnZ - previousobjectSpawnZ);
                }
            }
            previousobjectSpawnX = objectSpawnX;
            previousobjectSpawnZ = objectSpawnZ;
            Instantiate(objectToSpawn, new Vector3(objectSpawnX, 0.1f, objectSpawnZ), Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    IEnumerator SpawnObjectsRandomly()
    {
        for(int i = 0; i < objectsToSpawn.Length; i++) 
        {
            objectSpawnX = Random.Range(spawningSurface.bounds.min.x, spawningSurface.bounds.max.x);
            objectSpawnZ = Random.Range(spawningSurface.bounds.min.z, spawningSurface.bounds.max.z);
            if (previousobjectSpawnX != 0f && previousobjectSpawnZ != 0f)
            {
                spawnPosDifferenceX = Mathf.Abs(objectSpawnX - previousobjectSpawnX);
                spawnPosDifferenceZ = Mathf.Abs(objectSpawnZ - previousobjectSpawnZ);
                while (spawnPosDifferenceX < 4f)
                {
                    objectSpawnX = Random.Range(spawningSurface.bounds.min.x, spawningSurface.bounds.max.x);
                    objectSpawnZ = Random.Range(spawningSurface.bounds.min.z, spawningSurface.bounds.max.z);
                    spawnPosDifferenceX = Mathf.Abs(objectSpawnX - previousobjectSpawnX);
                    spawnPosDifferenceZ = Mathf.Abs(objectSpawnZ - previousobjectSpawnZ);
                }
            }
            previousobjectSpawnX = objectSpawnX;
            previousobjectSpawnZ = objectSpawnZ;
            Instantiate(objectsToSpawn[i], new Vector3(objectSpawnX, 0.1f, objectSpawnZ), Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
