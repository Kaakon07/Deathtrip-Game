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
    private float minRange = 30f;
    private float maxRange = 40f;

    // difficulty
    public float DiffLevel;

    // Enemy spawner timer!!! :D
    private float timer = 0;
    private float threshhold = 7.4f;




    // slutter spillet ved å kalle en funksjon
    public void GameOver()
    {
        GameOverScreen.Setup();
        
    }


    private void FixedUpdate()
    {
        // Difficulty timer
        DiffLevel = Mathf.Floor(Time.time * 0.01694915254f) + 1;


        
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

    public void enemySpawner()
    {

        Instantiate(Enemy, enemyPosMethod(), Enemy.transform.rotation);
    }

    public Vector3 enemyPosMethod()
    {
        float randAngle = UnityEngine.Random.Range(0, Mathf.PI*2);
        float randRadius = UnityEngine.Random.Range(minRange, maxRange);


        return new Vector3(Mathf.Cos(randAngle)*randRadius, Mathf.Sin(randAngle)*randRadius, 0);
    }   

}
