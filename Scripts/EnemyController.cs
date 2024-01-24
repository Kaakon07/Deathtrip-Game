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
    public GameObject XpOrb;
    public GameObject Controller;
    private GameController gameControl;
    private SpriteRenderer spriteRenderer;
    private Color baseColor;

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

        // base farge
        baseColor = spriteRenderer.color;

        // Vanskelighets Skala
        maxHealth = 20 + (4 * gameControl.DiffLevel - 1);
        health = maxHealth;
        damage = 20 + (2 * gameControl.DiffLevel - 1);


}


    

    void FixedUpdate()
    {
       



        // hvis fienden rører spilleren, gjør den skade på spilleren
        if (timer < threshhold)
        {
            timer++;
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
            for (int i = 0; i < gameControl.DiffLevel; i++) 
            {
                Vector3 randomVals = new Vector3(Random.value,Random.value,0);
                Instantiate(XpOrb, transform.position + randomVals, transform.rotation);
                aSource.PlayOneShot(deathClip,0.5f);
                Destroy(gameObject);
            }

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
            if (bulletScript.dealtDmg == false)
            {
                EnemyDamage(bulletScript.Damage);
                FlashRed();
            }
            bulletScript.dealtDmg = true;
            // sjekker om skuddet kan pierce eller bounce
            if (bulletScript.pierce > 0 )
            {
                bulletScript.dealtDmg = false;
                bulletScript.pierce -= 1;
            }
            else if (bulletScript.bounce > 0)
            {
                // stopper spilelt fra å ødelegge objected vis det kan sprette
            }
            else
            {
                // ødelegger skuddet
                Destroy(collision.gameObject);
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