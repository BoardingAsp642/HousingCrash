using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }



    public void QuitGame()
    {
        Application.Quit();
    }





}
