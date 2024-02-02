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
    public GameController gameController;
    public UpgradableScript upgradableScript;
    public HpText hpText;
    public MoveScript moveScript;
    public ShooterScript shooterScript;
    public AudioSource aSource;
    public AudioClip upgradeNoise;
    public AudioClip levelUpSound;
    public DrunkBarScript drunkScript;
    public LevelTextScript levelText;

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


        // En kalkulasjon som kalkulerer hvor mye XP du trenger for og levle opp, basert på ditt level
        //maxExp = Mathf.Round(100 * Mathf.Pow(2,Level/8));
        //maxExp = 12.5f * Mathf.Round(8 + 8 * Mathf.Pow(Level, 0.36787944111f))
        maxExp = 75 + Level*25;




    }

    // Update is called once per frame
    void Update()
    {
        // bruker kalkulasjonen nevnet tidligere til å konstant sette max XP verdien, så den går opp med ditt level
        maxExp = 75 + Level * 25;

        // skifter konstant maxHp og maxXP til hp baren og xp baren

        if (currentHealth < maxHealth)
        {
            currentHealth += 0.5f * Time.deltaTime;
        }
    

        //Kaller en funksjon som sjekker om du er død, og om du har nokk XP til å levele opp
        endGame();
        levelUp();
        levelText.ChangeText();

        // skifter HP teksten
        hpText.text.text = hpText.ChangeCurrent( Mathf.Floor(currentHealth*10)*0.1f ) + "\n/\n" + hpText.ChangeMax( Mathf.Floor(maxHealth * 10) * 0.1f );
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
        if(currentExp >= maxExp)
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
        aSource.PlayOneShot(upgradeNoise,0.3f);

        // tar vekk oppgraderingen fra oppgraderinger du kan få
        if (upgradeData.upgradeType == UpgradeType.BulletUpgrade)
        {
            upgradeData.Rarity = 0;
            if (shooterScript.explode == false)
            {
                if (upgradeData.Name == "Rocket")
                {
                    shooterScript.explode = true;
                }
            }
            


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

    public int findUpgradeFromIndex(float index)
    {
        int listIndex = Upgrades.Count-1;
        while (index > 0)
        {
            index -= Upgrades[listIndex].Rarity;
            listIndex--;
        }
        return listIndex+1;
    }

    public float findUpgradeRaritySum()
    {
        float raritySum = 0;
        for (int listIndex = 0; listIndex < Upgrades.Count; listIndex++)
        {
            raritySum += Upgrades[listIndex].Rarity;
        }
        return raritySum;
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
        Debug.Log(findUpgradeRaritySum().ToString());
        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(Upgrades[findUpgradeFromIndex(Random.Range(0, findUpgradeRaritySum()))]); //Random.Range(0, Upgrades.Count)
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
            else if (getUpgrade[i].statType == "shots")
            {
                shooterScript.shots += (int)getUpgrade[i].amount;
                getUpgrade.Remove(getUpgrade[i]);
            }

        }
    }



        
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("alchohol"))
        {
            drunkScript.Promille += Time.deltaTime * 0.5f * (gameController.DiffLevel+1);
            drunkScript.totalPromille += Time.deltaTime * 0.5f;
            
        }
    }
}



/*Undertale: The Musical Lyrics
[Intro]
Whoa - oh - oh - oh - oh - oh - oh - oh - oh - oh
Story of UNDERTALE
I fell from the light
Talk? Or should I fight?
Monster genocide
This my UNDERTALE

[Verse 1]
I fell through a cave on Mt. Ebott
I faced an evil talking flower in a pot
Explains the plot, wants me dead, wants me to rot
Toriel saves me, takes me to her home
And hooks me up with a brand-new monster phone
Leaves me alone, but I escape and meet some bones

[Pre-Chorus]
Should I be a pacifist?
Or should I use my fists?
I’m feeling evil, think I’ll kill them all

[Chorus]
I’m homicidal, and I’ve got a taste
I want to wipe out the Monster race
I’ve got no patience, got no resolve
I will slaughter, screw the dialogue
[Bridge]
I fell from the light
Talk? Or should I fight?
Monster genocide
This my UNDERTALE

[Verse 2]
I’ll slaughter Undyne, I’ll waste who I choose
With all this EXP there’s no way that I’ll lose
Now watch me move, I won’t stop, I’m feelin' rude
Asgore is shaking, he hears my approach
I’ll slaughter Sans and squash his bro like a roach
Chara’s my coach, all these monsters I will poach

[Pre-Chorus]
Screw being pacifist
I think I’ll use my fists
I’m feeling evil, think I’ll kill them all

[Chorus]
I’m homicidal, and I’ve got a taste
I want to wipe out the Monster race
I’ve got no patience, got no resolve
I will slaughter, screw the dialogue

[Bridge]
Burnt pan, toy knife, use a stick to take your life
Tough glove, ballet shoes, epic fight like front page news
King Asgore wants to collect human souls
Seven of them, is his ultimate goal
Open the door, to humanity’s realm
Start a new war, humans overwhelm
[Chorus]
I’m homicidal, and I’ve got a taste
I want to wipe out the Monster race
I’ve got no patience, got no resolve
I will slaughter, screw the dialogue*/
