using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    private float minDistance = 1f;
    private float range;
    private GameObject Player;
    public Collider2D enemyCollider;
    public Collider2D playerCollider;
    public ValueScript HealthScript;
    public float damage = 20f;
    


    private void Start()
    {
        Player = GameObject.Find("Player");
        target = Player.transform;
        playerCollider = Player.GetComponent<Collider2D>();
        enemyCollider = GetComponent<Collider2D>();
        HealthScript = GetComponent<ValueScript>();
    }

    void Update()
    {

        enemyDamage(damage);
        

        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void enemyDamage(float damage)
    {
        if (enemyCollider.IsTouching(playerCollider))
        {
            HealthScript.dealDamage(damage);
        }
    }
}