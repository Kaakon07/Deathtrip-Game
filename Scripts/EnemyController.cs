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
    public float health = 20f;
    public float damage = 20f;

    // referanser
    private GameObject Player;
    private Collider2D enemyCollider;
    private Collider2D playerCollider;
    private ValueScript HealthScript;
    private Transform target;
    private Rigidbody2D rb;
    public GameObject XpOrb;

    // Difficulty Timer
    private float DiffLevel;

    // Timer
    private float timer = 0;
    private float threshhold = 25;

    


    void Start()
    {
        // initialiserer diff level
        DiffLevel = 0;

        // definerer referanser, fordi det er en prefab
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        target = Player.transform;
        playerCollider = Player.GetComponent<Collider2D>();
        enemyCollider = GetComponent<Collider2D>();
        HealthScript = Player.GetComponent<ValueScript>();
    }

    void FixedUpdate()
    {
        // Difficulty timer
        DiffLevel = Mathf.Floor(Time.time * 0.0212765957446808510638f);



        // hvis fienden rører spilleren, gjør den skade på spilleren
        if (timer < threshhold)
        {
            timer++;
        }
        else if (enemyCollider.IsTouching(playerCollider))
        {
            HealthScript.dealDamage(damage);
            timer = 0;
        }

        
        // hvis fiended har helse av 0 eller mindre, forsvinner den og lager en XP orb
        if (health <= 0)
        {
            Instantiate(XpOrb, transform.position, transform.rotation);
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
        if (collision.gameObject.tag == "Bullet")
        {
            BulletScript bulletScript = collision.gameObject.GetComponent<BulletScript>();
            // sjekker om den har allerede gjor skade
            if (bulletScript.dealtDmg == false)
            {
                EnemyDamage(bulletScript.Damage);
                
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
                //
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



}