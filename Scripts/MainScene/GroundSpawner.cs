using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    
    //Variables
    public GameObject groundPrefab;
    public float spawnDelay;
    public float spawnInterval;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("spawnGround", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnGround()
    {
        if (gameManager.gameActive == true)
        {
            Vector3 spawnPoint = new Vector2(transform.position.x, transform.position.y);
            Instantiate(groundPrefab, spawnPoint, groundPrefab.transform.rotation);
        }
    }











}
