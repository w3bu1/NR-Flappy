using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnRate = 5f;

    public float heightOffset = 10.0f;

    private float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawn < spawnRate)
        {
            nextSpawn += Time.deltaTime;
        }
        else
        {
            SpawnBox();
            nextSpawn = 0;
        }
    }

    void SpawnBox()
    {
        float lowestY = transform.position.y - heightOffset;
        float highestY = transform.position.y + heightOffset;

        GameObject cloud = Instantiate(cloudPrefab, new Vector3(transform.position.x, Random.Range(lowestY, highestY), 0), transform.rotation);
        cloud.transform.parent = transform;
    }
}
