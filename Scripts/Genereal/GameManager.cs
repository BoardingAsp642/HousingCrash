using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //Variables
    public int points;
    public int health;
    public bool gameActive;


    [Header("Components")]
    public TextMeshProUGUI healthAndPointsText;

    [Header("Events")]

    public UnityEvent onMoneyChanged;

    //Singleton
    public static GameManager instance;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameActive = true;
        UpdateHealthAndPointsText();
    }

    void UpdateHealthAndPointsText()
    {
        healthAndPointsText.text = $"Health: {health}\nMoney: ${points}";
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHealthAndPointsText();

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameActive = false;

    }

    void WinGame()
    {
        gameActive = false;
    }

    /*public void OnEnemyDestroyed()
    {

        if (!gameAcive)
            return;
        if ()
        {
            WinGame();
        }


    }*/
}
