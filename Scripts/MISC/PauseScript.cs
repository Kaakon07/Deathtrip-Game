using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    // referanse for � stoppe spilelt fra � kj�re n�r du er i oppgraderingsmenyen
    public GameObject upgradeScreen;


    // Bool som sjekker om spillet er pauset allerede
    public bool Paused = false;

    // Viser pause menyen, og f�r all fysikk til � stoppe
    public void Pause()
    {
        if (upgradeScreen.activeSelf == false)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            Paused = true; 
        }

    }
    // hjemmer menyen, og starter all fysikk
    public void UnPause()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }
}
