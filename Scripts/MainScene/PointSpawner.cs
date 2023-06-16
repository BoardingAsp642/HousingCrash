using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    // Variables
    public GameObject pointPrefab;
    public float spawnDelay;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("StartSpawning", spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartSpawning()
    {
        if (gameManager.gameActive == true)
        {
            SpawnPoint();
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            Invoke("StartSpawning", randomInterval);
        }
    }

    private void SpawnPoint()
    {
        Vector3 spawnPoint = new Vector2(transform.position.x, transform.position.y);
        Instantiate(pointPrefab, spawnPoint, pointPrefab.transform.rotation);
    }
}
