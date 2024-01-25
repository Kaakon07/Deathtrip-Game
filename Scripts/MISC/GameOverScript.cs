using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameOverScript : MonoBehaviour
{

    public AudioMixer mixer;

    // Viser game over skjermen
    public void Setup()
    {
        mixer.SetFloat("gameVolume", -80);
        gameObject.SetActive(true);
        
    }

    // Starter spillet på nytt
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    // Åpner main menu
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
