using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI bodyText;

    public void SetEndScreen(bool didWin, int roundsSurvived)
    {
        headerText.text = didWin ? "YOU WIN!!" : "GAME OVER!!";
        headerText.color = didWin ? Color.green : Color.red;
        bodyText.text = $"You Survived {roundsSurvived} rounds";
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
