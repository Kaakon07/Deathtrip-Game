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
    public float moveSpeed;


    // Referanser til til spillobjekter og andre scripter
    public HealthBarScript healthBar;
    public GameController gameController;
    public XPbarScript xpBar;
    public UpgradableScript upgradableScript;
    public HpText hpText;
    public MoveScript moveScript;
    public ShooterScript shooterScript;
    public AudioSource aSource;
    public AudioClip upgradeNoise;
    public AudioClip levelUpSound;

    // Initsialisering av lister, som lagrer oppgraderinger du velger, og vilke du har tatt
    public List<UpgradeData> Upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgrades;
    [SerializeField]List<UpgradeData> getUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        // movespeed
        moveSpeed = 20f;
        // Setter start verdien av variablene
        Level = 1;
        currentHealth = maxHealth;
        currentExp = 0;

        // Setter max verdien til spilobjektet "healthBar"
        healthBar.SetMaxHealth(maxHealth);

        // En kalkulasjon som kalkulerer hvor mye XP du trenger for og levle opp, basert på ditt level
        maxExp = Mathf.Round(100 * Mathf.Pow(2,Level/8));

        

        // Setter max verdien til spilobjektet "xpBar"
        xpBar.SetMaxXp(maxExp);
    }

    // Update is called once per frame
    void Update()
    {
        // bruker kalkulasjonen nevnet tidligere til å konstant sette max XP verdien, så den går opp med ditt level
        maxExp = 100 * Mathf.Pow(2, Level / 8);

        // skifter konstant maxHp og maxXP til hp baren og xp baren
        xpBar.SetMaxXp(maxExp);
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth < maxHealth)
        {
            currentHealth += 0.5f * Time.deltaTime;
        }

        // sette nåtidlige XPen din til nåtidlige XPen til XP baren
        xpBar.SetXP(currentExp);

        //Kaller en funksjon som sjekker om du er død, og om du har nokk XP til å levele opp
        endGame();
        levelUp();

        // skifter HP teksten
        hpText.text.text = hpText.ChangeCurrent(currentHealth) + "/" + hpText.ChangeMax(maxHealth);
    }

    // En metode som lar deg gjøre skade til spilleren
    public void dealDamage(float dmg)
    {
        currentHealth -= dmg;
        
    }

    // Funksjon som sjekker om du kan levele opp, og om du kan, åpner en oppgraderings meny
    public void levelUp()
    {

        // sjekker om du har nokk til og levele opp
        if(currentExp > maxExp-1)
        {
            aSource.PlayOneShot(levelUpSound);
            // sjekker om selectedUpgrades er tom, og om den er det, gir den verdien av en liste med enumen UpgradeData som type
            if (selectedUpgrades == null)
            {
                selectedUpgrades = new List<UpgradeData>();
            }
            // Tømmer selected upgrades listen
            selectedUpgrades.Clear();

            // Legger till oppgraderingene du kan velge ved å kalle GetUpgrade metoden, definert lenger ned
            selectedUpgrades.AddRange(GetUpgrade(3));

            // Lar deg beholde xp du har over max xp
            currentExp -= maxExp;
            // Levelt går opp med 1
            Level++;

            // Viser oppgraderings menyen
            upgradableScript.ShowUpgrade(selectedUpgrades);
        }
    }

    // Legger til oppgraderingen du valgte til en liste med oppgradering du har fått
    public void Upgrade(int selectedUpgradeID)
    {
        // definerer en variabel er selectedUpgrade med indexen av vilken du valgte, så den vet vilken av de 3 valgene du valgte
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];

        // vis listen er tom, lag en liste, bla bla bla du skjønner
        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        // Legger till oppgradering du valgte til oppgraderinger du har
        acquiredUpgrades.Add(upgradeData);
        aSource.PlayOneShot(upgradeNoise);
        // tar vekk oppgraderingen fra oppgraderinger du kan få
        if (upgradeData.upgradeType == UpgradeType.BulletUpgrade)
        {
            Upgrades.Remove(upgradeData);
        }
        else
        {
            // legger till stats
            getUpgrade.Add(upgradeData);
            acquiredUpgrades.Remove(upgradeData);
            RecieveStatUpgrade();
        }
        
        
            
    }
    
    // gir deg XP
    public void GiveXp(float xp)
    {
        currentExp += xp;
    }

    // slutter spillet, viser game over skjermen ved å sjekke om du er under 1 hp
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

        // vis den prøver å hente inn flere oppgraderinger en det er mulig, setter den hvor mange den henter in til hvor mange som er mulige å få
        if (count > Upgrades.Count)
        {
            count = Upgrades.Count;
        }

        // legger til en tilfeldig oppgradering til de du kan få
        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(Upgrades[Random.Range(0, Upgrades.Count)]);
        }
        
        // returner upgradeList
        return upgradeList;
    }

    // gir deg stat oppgraderingen
    public void RecieveStatUpgrade()
    {
        for (int i =0; i < getUpgrade.Count; i++) 
        {
            if (getUpgrade[i].statType == "speed")
            {
                moveSpeed += getUpgrade[i].amount;
                getUpgrade.Remove(getUpgrade[i]);
            }
            else if (getUpgrade[i].statType == "health")
            {
                maxHealth += getUpgrade[i].amount;
                getUpgrade.Remove(getUpgrade[i]);
            }
            else if (getUpgrade[i].statType == "firespeed")
            {
                 shooterScript.FireSpeed += getUpgrade[i].amount;
                getUpgrade.Remove(getUpgrade[i]);
            }
            else if (getUpgrade[i].statType == "bulletspeed")
            {
                shooterScript.BulletSpeed += getUpgrade[i].amount;
                getUpgrade.Remove(getUpgrade[i]);
            }
            else if (getUpgrade[i].statType == "damage")
            {
                shooterScript.Damage += getUpgrade[i].amount;
                getUpgrade.Remove(getUpgrade[i]);
            }
            else if (getUpgrade[i].statType == "range")
            {
                shooterScript.range += getUpgrade[i].amount;
                getUpgrade.Remove(getUpgrade[i]);
            }
            else if (getUpgrade[i].statType == "bounce")
            {
                shooterScript.bounce += (int)getUpgrade[i].amount;
                getUpgrade.Remove(getUpgrade[i]);
            }
            else if (getUpgrade[i].statType == "pierce")
            {
                shooterScript.pierce     += (int)getUpgrade[i].amount;
                getUpgrade.Remove(getUpgrade[i]);
            }

        }
    }
}
