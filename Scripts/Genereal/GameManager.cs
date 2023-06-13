using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    //Variables
    public int health;
    public int points;
    private bool gameAcive;


    [Header("Components")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI pointText;
    public EndScreenUI endScreen;

    [Header("Events")]

    public UnityEvent onMoneyChanged;

    //Singleton
    public static GameManager instance;


    /*private void Awake()
    {
        instance = this;
    }*/

    private void Start()
    {
        gameAcive = true;
        UpdateHealthText();
        UpdatePointText();
    }

    void UpdateHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    void UpdatePointText()
    {
        pointText.text = $"Points: {points}";
    }



    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHealthText();

        if (health <= 0)
        {
            GameOver();
            pointText.text = $"Points: {points == 0}";
        }
    }

    void GameOver()
    {
        gameAcive = false;
        endScreen.gameObject.SetActive(true);
    }

    void WinGame()
    {
        gameAcive = false;
        endScreen.gameObject.SetActive(true);
    }

    /*public void OnEnemyDestroyed()
    {

        if (!gameAcive)
            return;
        if (waverSpawner.remainingEnemies == 0 && waverSpawner.curWave == waverSpawner.waves.Length)
        {
            WinGame();
        }


    }*/
}
