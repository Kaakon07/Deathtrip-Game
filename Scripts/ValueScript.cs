using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueScript : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentHealth);  
    }
}
