using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    // referanser
    public GameOverScript GameOverScreen;
    public PauseScript PauseScreen;
    public GameObject Enemy;
    public GameObject Player;
    public AudioMixer mixer;
    public ValueScript vScript;

    // hvor langt unna enemies spawner
    private float minRange = 30f;
    private float maxRange = 40f;

    // difficulty
    public float DiffLevel;

    // Enemy spawner timer!!! :D
    private float timer = 0;
    private float threshhold = 1500f;

    // enemy spawn amount
    private int enemiesSpawnAmount;





    private void Start()
    {
        enemiesSpawnAmount = 3;
        for (int i = 0; i < Mathf.Floor(enemiesSpawnAmount); i++)
        {
            enemySpawner();
        }
        mixer.SetFloat("gameVolume", 0);

    }

    // slutter spillet ved å kalle en funksjon
    public void GameOver()
    {
        GameOverScreen.Setup();
    }


    private void FixedUpdate()
    {
        // Difficulty timer
        DiffLevel = Mathf.Floor(Time.time * 0.01694915254f) + 1;

        if (timer < threshhold)
        {
            timer += 1;
        }
        else
        {
            for (int i = 0; i < Mathf.Floor(enemiesSpawnAmount); i++)
            {
                enemySpawner();
            }
            enemiesSpawnAmount += 2;
            timer = 0;
        }


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


        return new Vector3(Mathf.Cos(randAngle)*randRadius + Player.transform.position.x, Mathf.Sin(randAngle)* randRadius + Player.transform.position.y, 0);
    }   

}
