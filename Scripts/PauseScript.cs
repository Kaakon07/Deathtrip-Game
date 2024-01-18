using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool Paused = false;
    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        Paused = true;
    }
    public void UnPause()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }
}
