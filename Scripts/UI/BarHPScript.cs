using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHPScript : MonoBehaviour
{
    // References
    public GameObject BarHpMask;
    public ValueScript valueScript;


    private RectMask2D BarMask;


    float hpFloat;



    void Start()
    {
        BarMask = BarHpMask.GetComponent<RectMask2D>();
    }



    void Update()
    {
        hpFloat = valueScript.currentHealth / valueScript.maxHealth;
        BarMask.padding = new Vector4(0, 0, 0, (1 - hpFloat) * 768);
    }
}
