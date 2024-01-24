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

    // difficulty
    private float DiffLevel;

    // slutter spillet ved å kalle en funksjon
    public void GameOver()
    {
        GameOverScreen.Setup();
        
    }


    private void FixedUpdate()
    {
        // Difficulty timer
        DiffLevel = Mathf.Floor(Time.time * 0.0487804878f);
        Debug.Log(DiffLevel.ToString());
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
