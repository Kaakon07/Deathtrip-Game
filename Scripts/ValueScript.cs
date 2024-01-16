using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ValueScript : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float Level;
    public float maxExp;
    public float currentExp;
    public HealthBarScript healthBar;
    public GameController gameController;
    public XPbarScript xpBar;

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        maxExp = 100 * Mathf.Pow(2,Level/8);
        currentExp = 0;
        xpBar.SetMaxXp(maxExp);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentHealth);
        xpBar.SetXP(currentExp);
        endGame();
        levelUp();
        maxExp = 100 * Mathf.Pow(2, Level / 8);
    }

    public void dealDamage(float dmg)
    {
        currentHealth -= dmg;
    }

    public void levelUp()
    {
        if(currentExp > maxExp-1)
        {
            currentExp -= maxExp;
            Level++;
        }
    }
    
    public void GiveXp(float xp)
    {
        currentExp += xp;
    }

    public void endGame()
    {
        if (currentHealth < 1) 
        {
            gameController.GameOver();
        }
    }
}
