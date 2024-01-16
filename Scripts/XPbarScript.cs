using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPbarScript : MonoBehaviour
{
    public Slider XPSlider;

    public void SetMaxXp(float xp)
    {
        XPSlider.maxValue = xp;
        
    }

    public void SetXP(float xp)
    {
        XPSlider.value = xp;
    }


}
