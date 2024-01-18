using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class GameController : MonoBehaviour
{
    public GameOverScript GameOverScreen;
    public PauseScript PauseScreen;


    public void GameOver()
    {
        GameOverScreen.Setup();
        
    }

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
