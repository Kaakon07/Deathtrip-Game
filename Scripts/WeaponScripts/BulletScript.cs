using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // referanser til spiller objektet og skyte skripten
    private GameObject Player;
    private ShooterScript ShootScript;
    private Rigidbody2D rb;
    public GameObject explode;
    

    // Stats
    public float Damage;
    public float range;
    public int pierce;
    public int bounce;

    // om den har gjort skade eller ikke
    public bool dealtDmg = false;

    Vector3 bulletPos;
    Vector3 playerPos;

    private void Start()
    {
        Player = GameObject.Find("Player");
        ShootScript = Player.GetComponent<ShooterScript>();
        rb = GetComponent<Rigidbody2D>();
        Damage = ShootScript.Damage;
        range = ShootScript.range;
        pierce = ShootScript.pierce;
        bounce = ShootScript.bounce;

        

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, range);
    }

    private void FixedUpdate()
    {
        bulletPos = rb.transform.position;
        playerPos = Player.transform.position;

        if (bounce > 0)
        {
            if (bulletPos.x < playerPos.x - 27 | bulletPos.x > playerPos.x + 27) // 27 x 15.1875
            {
                Debug.Log("bullet has hit the wall");
                rb.velocity = new Vector2(0 - rb.velocity.x, rb.velocity.y);
                rb.rotation = Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.y, rb.velocity.x) - 90;
                bounce--;
                dealtDmg = false;
            }
            if (bulletPos.y < playerPos.y - 15.1875f | bulletPos.y > playerPos.y + 15.1875f) // 27 x 15.1875
            {
                Debug.Log("bullet has hit the wall");
                rb.velocity = new Vector2(rb.velocity.x, 0 - rb.velocity.y);
                rb.rotation = Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.y, rb.velocity.x) - 90;
                bounce--;
                dealtDmg = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //if (ShootScript.explode == true)
            //{
            //    Instantiate(explode);
            //}
        }
    }
}
