using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawner : MonoBehaviour
{
    //Variables
    public GameObject sceneryPrefab;
    public float spawnDelay;
    public float spawnInterval;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("spawnScenery", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnScenery()
    {
        if (gameManager.gameActive == true)
        {
            Vector3 spawnPoint = new Vector2(transform.position.x, transform.position.y);
            Instantiate(sceneryPrefab, spawnPoint, sceneryPrefab.transform.rotation);
        }
    }
}
