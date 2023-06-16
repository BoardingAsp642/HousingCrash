using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variables
    public int points;
    public int health;
    public bool gameActive;



    [Header("Components")]
    public TextMeshProUGUI healthAndPointsText;


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

    // Called when the player loses



    void UpdateHealthAndPointsText()
    {
        healthAndPointsText.text = $"Health: {health}\nPoints: {points}";
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
        SceneManager.LoadScene("EndScreem");
    }

    public void AddPoint()
    {
        points += 5;
        UpdateHealthAndPointsText();
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
