using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class HealthBarScript : MonoBehaviour
{
    public Slider healthBarSlider;

    public void SetMaxHealth(float health)
    {
        healthBarSlider.maxValue = health;
        healthBarSlider.value = health;
    }

    public void SetHealth(float health)
    {
        healthBarSlider.value = health;
    }
}
