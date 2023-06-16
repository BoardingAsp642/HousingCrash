using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //Variables
    public GameObject obstaclePrefab;
    public float spawnDelay;
    public float spawnInterval;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval = Random.Range(0, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle()
    {

        if (gameManager.gameActive == true)
        {
            Vector3 spawnPoint = new Vector2(transform.position.x, transform.position.y);
            Instantiate(obstaclePrefab, spawnPoint, obstaclePrefab.transform.rotation);


        }
    }
}
