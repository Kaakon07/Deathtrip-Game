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
    public GameObject Enemy;
    public GameObject Player;

    // hvor langt unna enemies spawner
    private float range = 30f;

    // difficulty
    public float DiffLevel;

    // slutter spillet ved � kalle en funksjon
    public void GameOver()
    {
        GameOverScreen.Setup();
        
    }


    private void FixedUpdate()
    {
        // Difficulty timer
        DiffLevel = Mathf.Floor(Time.time * 0.01694915254f) + 1;
        
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

    public void enemySpawner()
    {

        //Instantiate(Enemy,);
    }

}
