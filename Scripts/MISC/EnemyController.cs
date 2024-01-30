using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class EnemyController : MonoBehaviour
{

    // stats
    public float speed = 2f;

    // hvor nerme fienden må være
    private float minDistance = 0f;
    private float range;

    // mer stats
    public float health;
    public float maxHealth;
    public float damage;

    // referanser
    private GameObject Player;
    private Collider2D enemyCollider;
    private Collider2D playerCollider;
    private ValueScript HealthScript;
    private Transform target;
    private Rigidbody2D rb;
    private GameObject Controller;
    private GameController gameControl;
    private SpriteRenderer spriteRenderer;
    private Color baseColor;
    public GameObject drunk;
    public GameObject XpOrb0;
    public GameObject XpOrb1;
    public GameObject XpOrb2;
    private ShooterScript shooterScript;


    // Timer
    private float timer = 0;
    private float threshhold = 25;

    // lyd
    public AudioClip deathClip;
    public AudioClip damageToPlayer;
    private AudioSource aSource;




    void Start()
    {


        // definerer referanser, fordi det er en prefab;
        Player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        Controller = GameObject.Find("GameController");
        gameControl = Controller.GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        target = Player.transform;
        aSource = Player.GetComponent<AudioSource>();
        playerCollider = Player.GetComponent<Collider2D>();
        enemyCollider = GetComponent<Collider2D>();
        HealthScript = Player.GetComponent<ValueScript>();
        shooterScript = Player.GetComponent<ShooterScript>();
        

        // base farge
        baseColor = spriteRenderer.color;

        // Vanskelighets Skala
        maxHealth = 20 + (4 * gameControl.DiffLevel);
        health = maxHealth;
        damage = 20 + (2 * gameControl.DiffLevel);


}


    

    void FixedUpdate()
    {
       



        // hvis fienden rører spilleren, gjør den skade på spilleren
        if (timer < threshhold)
        {
            timer += 1;
        }
        else if (enemyCollider.IsTouching(playerCollider))
        {
            HealthScript.dealDamage(damage);
            aSource.PlayOneShot(damageToPlayer);
            timer = 0;
        }

        
        // hvis fiended har helse av 0 eller mindre, forsvinner den og lager en XP orb
        if (health <= 0)
        {
            int xpOrbSpawn = (int)gameControl.DiffLevel + 1; // How much xp/20 to spawn
            for (int i = 0; i < (xpOrbSpawn & 3); i++) // How many small xp orbs to spawn
            {
                Vector3 randomVals = new Vector3(Random.value, Random.value, 0);
                Instantiate(XpOrb0, transform.position + randomVals, transform.rotation);
            }

            for (int i = 0; i < (xpOrbSpawn >> 2 & 3); i++) // How many medium xp orbs to spawn
            {
                Vector3 randomVals = new Vector3(Random.value, Random.value, 0);
                Instantiate(XpOrb1, transform.position + randomVals, transform.rotation);
            }

            for (int i = 0; i < (xpOrbSpawn >> 4); i++) // How many large xp orbs to spawn
            {
                Vector3 randomVals = new Vector3(Random.value, Random.value, 0);
                Instantiate(XpOrb2, transform.position + randomVals, transform.rotation);
            }


            aSource.PlayOneShot(deathClip, 0.5f);
            gameControl.enemiesKilled += 1;
            Instantiate(drunk, transform.position, transform.rotation);
            Destroy(gameObject);

        }


        
        
        // hvor langt unna fienden stopper å følge deg
        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // hvis noe med "bullet" taggen rører fiended, gjør den skade
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript bulletScript = collision.gameObject.GetComponent<BulletScript>();
            // sjekker om den har allerede gjor skade
            if (bulletScript.dealtDmg == false )
            {
                EnemyDamage(bulletScript.Damage);
                
                if (shooterScript.explode == true) 
                {
                    bulletScript.Explode(collision.transform.position,collision.transform.rotation);
                }
                
                FlashRed();
            }
            bulletScript.dealtDmg = true;
            // sjekker om skuddet kan pierce eller bounce
            if (bulletScript.pierce > 0 )
            {
                bulletScript.dealtDmg = false;
                bulletScript.pierce -= 1;
            }
            else
            {
                // ødelegger skuddet
                
                Destroy(collision.gameObject);
            }
            
        }

        if (collision.gameObject.CompareTag("Explosion"))
        {
            ExplodeScript explodeScript = collision.gameObject.GetComponent<ExplodeScript>();
            if(explodeScript.dealtDamage == false) 
            {
                EnemyDamage(shooterScript.Damage * 0.25f);
                explodeScript.dealtDamage = true;
            }

        }
    }

    // gjør skade på fienden
    public void EnemyDamage(float dmg)
    {
        health -= dmg;
    }

    // skifter fargen til rød når fienden tar skade
    void FlashRed()
    {
        spriteRenderer.color = Color.red;
        Invoke(nameof(ResetColor), 0.1f);
    }

    void ResetColor()
    {
        spriteRenderer.color = baseColor;
    }

}