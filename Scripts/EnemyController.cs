using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class EnemyController : MonoBehaviour
{

    // stats
    public float speed = 2f;

    // hvor nerme fienden m� v�re
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

    


    void Start()
    {
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
        // hvis fienden r�rer spilleren, gj�r den skade p� spilleren
        if (enemyCollider.IsTouching(playerCollider))
        {
            HealthScript.dealDamage(damage);
            
        }

        
        // hvis fiended har helse av 0 eller mindre, forsvinner den og lager en XP orb
        if (health <= 0)
        {
            Instantiate(XpOrb, transform.position, transform.rotation);
            Destroy(gameObject);
        }


        
        
        // hvor langt unna fienden stopper � f�lge deg
        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // hvis noe med "bullet" taggen r�rer fiended, gj�r den skade
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
                //
            }
            else if (bulletScript.bounce > 0)
            {
                //
            }
            else
            {
                // �delegger skuddet
                Destroy(collision.gameObject);
            }
            
        }
    }

    // gj�r skade p� fienden
    public void EnemyDamage(float dmg)
    {
        health -= dmg;
    }



}