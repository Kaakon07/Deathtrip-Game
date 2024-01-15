using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueScript : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBarScript healthBar;
    public GameController gameController;

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
        endGame();
    }

    public void dealDamage(float dmg)
    {
        currentHealth -= dmg;
    }
    


    public void endGame()
    {
        if (currentHealth < 1) 
        {
            gameController.GameOver();
        }
    }
}
