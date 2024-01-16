using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextScript : MonoBehaviour
{
    public Text text;
    public ValueScript script;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Level " + script.Level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level " + script.Level.ToString();
    }
}
