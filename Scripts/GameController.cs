using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameOverScript GameOverScreen;


    public void GameOver()
    {
        GameOverScreen.Setup();
    }



}
