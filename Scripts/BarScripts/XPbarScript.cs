using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPbarScript : MonoBehaviour
{
    // Styrer xp baren
    public Slider XPSlider;

    // setter max verdien
    public void SetMaxXp(float xp)
    {
        XPSlider.maxValue = xp;
    }

    // setter verdien
    public void SetXP(float xp)
    {
        XPSlider.value = xp;
    }


}
