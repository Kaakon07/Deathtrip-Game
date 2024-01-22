using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // referanser
    public GameOverScript GameOverScreen;
    public PauseScript PauseScreen;

    // slutter spillet ved å kalle en funksjon
    public void GameOver()
    {
        GameOverScreen.Setup();
        
    }

    // sjekker om du trykker esc, om du gjør det pauser spillet, eller hvis spillet er pauset, upauser det
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseScreen.Paused == false)
        {
            PauseScreen.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseScreen.Paused == true)
        {
            PauseScreen.UnPause();
        }
    }
}
