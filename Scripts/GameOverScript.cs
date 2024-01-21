using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
 
    // Viser game over skjermen
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    // Starter spillet p� nytt
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    // �pner main menu
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
