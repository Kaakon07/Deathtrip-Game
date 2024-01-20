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
    public UpgradableScript upgradableScript;
    public List<UpgradeData> Upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        maxExp = Mathf.Round(100 * Mathf.Pow(2,Level/8));
        currentExp = 0;
        xpBar.SetMaxXp(maxExp);
    }

    // Update is called once per frame
    void Update()
    {
        maxExp = 100 * Mathf.Pow(2, Level / 8);
        xpBar.SetMaxXp(maxExp);
        healthBar.SetHealth(currentHealth);
        xpBar.SetXP(currentExp);
        endGame();
        levelUp();
    }

    public void dealDamage(float dmg)
    {
        currentHealth -= dmg;
    }

    public void levelUp()
    {


        if(currentExp > maxExp-1)
        {
            if (selectedUpgrades == null)
            {
                selectedUpgrades = new List<UpgradeData>();
            }
            selectedUpgrades.Clear();
            selectedUpgrades.AddRange(GetUpgrade(3));

            currentExp -= maxExp;
            Level++;
            upgradableScript.ShowUpgrade(selectedUpgrades);
        }
    }

    public void Upgrade(int selectedUpgradeID)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];
        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        acquiredUpgrades.Add(upgradeData);
        Upgrades.Remove(upgradeData);
            
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
    public List<UpgradeData> GetUpgrade(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > Upgrades.Count)
        {
            count = Upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(Upgrades[Random.Range(0, Upgrades.Count)]);
        }
        

        return upgradeList;
    }
}
