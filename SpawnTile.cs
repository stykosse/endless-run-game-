using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObject;

    public GameObject obstacle;
    public GameObject obstaclespawn;

    public float timeOffset = 0.4f;
    public float distanceBetweenTiles = 5.0F;
    public float randomValue = 0.8f;
    private Vector3 previousTilePosition;
    private Vector3 previousobstaclePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        previousobstaclePosition = obstacle.transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
                direction = mainDirection;
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
            }
            Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;
            Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            previousTilePosition = spawnPos;
        }
          if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
                direction = mainDirection;
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
            }
            Vector3 obsposi = previousobstaclePosition + distanceBetweenTiles * direction;
            startTime = Time.time;
            Instantiate(obstaclespawn, obsposi, Quaternion.Euler(0, 0, 0));
            previousobstaclePosition = obsposi;
        }
    }
}