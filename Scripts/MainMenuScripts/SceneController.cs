using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public AudioSource source;

    private void Start()
    {
        
    }
    // skifter scene
    public void Load(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Quit()
    {
        Application.Quit();

    }
}
