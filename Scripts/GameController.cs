using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class GameController : MonoBehaviour
{
    // referanser
    public GameOverScript GameOverScreen;
    public PauseScript PauseScreen;

    // slutter spillet
    public void GameOver()
    {
        GameOverScreen.Setup();
        
    }

    // sjekker om du trykker esc, om du gj�r det pauser spillet, eller hvis spillet er pauset, upauser det
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
