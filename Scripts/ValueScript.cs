using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ValueScript : MonoBehaviour
{
    // Initialiserer variablene som lagrer hp, xp og deres max value
    public float maxHealth = 100;
    public float currentHealth;
    public float Level;
    public float maxExp;
    public float currentExp;


    // Referanser til til spillobjekter og andre scripter
    public HealthBarScript healthBar;
    public GameController gameController;
    public XPbarScript xpBar;
    public UpgradableScript upgradableScript;

    // Initsialisering av lister, som lagrer oppgraderinger du velger, og vilke du har tatt
    public List<UpgradeData> Upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        // Setter start verdien av variablene
        Level = 1;
        currentHealth = maxHealth;
        currentExp = 0;

        // Setter max verdien til spilobjektet "healthBar"
        healthBar.SetMaxHealth(maxHealth);

        // En kalkulasjon som kalkulerer hvor mye XP du trenger for og levle opp, basert p� ditt level
        maxExp = Mathf.Round(100 * Mathf.Pow(2,Level/8));

        

        // Setter max verdien til spilobjektet "xpBar"
        xpBar.SetMaxXp(maxExp);
    }

    // Update is called once per frame
    void Update()
    {
        // bruker kalkulasjonen nevnet tidligere til � konstant sette max XP verdien, s� den g�r opp med ditt level
        maxExp = 100 * Mathf.Pow(2, Level / 8);

        // skifter konstant maxHp og maxXP til hp baren og xp baren
        xpBar.SetMaxXp(maxExp);
        healthBar.SetHealth(currentHealth);

        // sette n�tidlige XPen din til n�tidlige XPen til XP baren
        xpBar.SetXP(currentExp);

        //Kaller en funksjon som sjekker om du er d�d, og om du har nokk XP til � levele opp
        endGame();
        levelUp();
    }

    // En metode som lar deg gj�re skade til spilleren
    public void dealDamage(float dmg)
    {
        currentHealth -= dmg;
    }

    // Funksjon som sjekker om du kan levele opp, og om du kan, �pner en oppgraderings meny
    public void levelUp()
    {

        // sjekker om du har nokk til og levele opp
        if(currentExp > maxExp-1)
        {
            // sjekker om selectedUpgrades er tom, og om den er det, gir den verdien av en liste med enumen UpgradeData som type
            if (selectedUpgrades == null)
            {
                selectedUpgrades = new List<UpgradeData>();
            }
            // T�mmer selected upgrades listen
            selectedUpgrades.Clear();

            // Legger till oppgraderingene du kan velge ved � kalle GetUpgrade metoden, definert lenger ned
            selectedUpgrades.AddRange(GetUpgrade(4));

            // Lar deg beholde xp du har over max xp
            currentExp -= maxExp;
            // Levelt g�r opp med 1
            Level++;

            // Viser oppgraderings menyen
            upgradableScript.ShowUpgrade(selectedUpgrades);
        }
    }

    // Legger til oppgraderingen du valgte til en liste med oppgradering du har f�tt
    public void Upgrade(int selectedUpgradeID)
    {
        // definerer en variabel er selectedUpgrade med indexen av vilken du valgte, s� den vet vilken av de 3 valgene du valgte
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];

        // vis listen er tom, lag en liste, bla bla bla du skj�nner
        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        // Legger till oppgradering du valgte til oppgraderinger du har
        acquiredUpgrades.Add(upgradeData);
        // tar vekk oppgraderingen fra oppgraderinger du kan f�
        if (upgradeData.upgradeType == UpgradeType.BulletUpgrade)
        {
            Upgrades.Remove(upgradeData);
        }
        
            
    }
    
    // gir deg XP
    public void GiveXp(float xp)
    {
        currentExp += xp;
    }

    // slutter spillet, viser game over skjermen ved � sjekke om du er under 1 hp
    public void endGame()
    {
        if (currentHealth < 1) 
        {
            gameController.GameOver();
        }
    }

    // Henter de mulige oppgraderingene, og legger det til en liste, som heter upgradeList
    public List<UpgradeData> GetUpgrade(int count)
    {
        // lager en liste
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        // vis den pr�ver � hente inn flere oppgraderinger en det er mulig, setter den hvor mange den henter in til hvor mange som er mulige � f�
        if (count > Upgrades.Count)
        {
            count = Upgrades.Count;
        }

        // legger til en tilfeldig oppgradering til de du kan f�
        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(Upgrades[Random.Range(0, Upgrades.Count)]);
        }
        
        // returner upgradeList
        return upgradeList;
    }
}
