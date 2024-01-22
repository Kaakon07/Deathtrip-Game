using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpText : MonoBehaviour
{
    public Text text;
    // Update is called once per frame

    public string ChangeMax(float maxHp)
    {
        return maxHp.ToString();
    }

    public string ChangeCurrent(float currentHp)
    {
        return currentHp.ToString();
    }
}
