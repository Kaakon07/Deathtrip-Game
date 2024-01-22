using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    // Bool som sjekker om spillet er pauset allerede
    public bool Paused = false;

    // Viser pause menyen, og får all fysikk til å stoppe
    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        Paused = true;
    }
    // hjemmer menyen, og starter all fysikk
    public void UnPause()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }
}
