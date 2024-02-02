using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextScript : MonoBehaviour
{
    // referanser
    public Text text;
    public ValueScript script;

    // Start is called before the first frame update
    void Start()
    {
        // skifter "Level" teksten på start
        ChangeText();
    }

    // Update is called once per frame
    public void ChangeText()
    {
        // skifter teksten konstant
        text.text = "Level " + script.Level.ToString();
    }
}
