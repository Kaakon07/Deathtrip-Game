using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarXPScript : MonoBehaviour
{
    // References
    public GameObject BarXpMask;
    public ValueScript valueScript;


    private RectMask2D BarMask;


    float xpFloat;



    void Start()
    {
        BarMask = BarXpMask.GetComponent<RectMask2D>();
    }



    void Update()
    {
        xpFloat = valueScript.currentExp / valueScript.maxExp;
        BarMask.padding = new Vector4(0, 0, (1 - xpFloat) * 512, 0);
    }
}
