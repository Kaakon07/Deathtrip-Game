using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class EnemyController : MonoBehaviour
{
    private Transform target;
    public float speed = 2f;
    private float minDistance = 0f;
    private float range;
    private GameObject Player;
    private Collider2D enemyCollider;
    private Collider2D playerCollider;
    private ValueScript HealthScript;
    public float damage = 20f;
    private Rigidbody2D rb;
    public float health = 20f;
    public GameObject XpOrb;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        target = Player.transform;
        playerCollider = Player.GetComponent<Collider2D>();
        enemyCollider = GetComponent<Collider2D>();
        HealthScript = Player.GetComponent<ValueScript>();
    }

    void FixedUpdate()
    {
        if (enemyCollider.IsTouching(playerCollider))
        {
            HealthScript.dealDamage(damage);
            rb.AddForce(rb.velocity*-1);
            
        }

        if ()

        if (health < 1)
        {
            Instantiate(XpOrb, transform.position, transform.rotation);
            Destroy(gameObject);
        }


        
        

        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void EnemyDamage(float dmg)
    {
        health = -dmg;
    }



}