using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarXPScript : MonoBehaviour
{
    public GameObject xpBarUI;
    public GameObject xpImageUI;
    public ValueScript valueScript;

    float xpFloat;
    // Start is called before the first frame update
    void Start()
    {
        xpImageUI = GameObject.Find("BarImageXP");
        Debug.Log(xpImageUI.transform.position.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        xpFloat = valueScript.currentExp / valueScript.maxExp;
        xpBarUI.transform.position = new Vector3(-199.28f + 398.56f * xpFloat, 914.12f, 0);
        xpImageUI.transform.position = new Vector3(199.28f, 914.12f, 0);

    }
}
