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
    //private Camera camera;
    

    // Stats
    public float Damage;
    public float range;
    public int pierce;
    public int bounce;

    // om den har gjort skade eller ikke
    public bool dealtDmg = false;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BounceWall") && bounce > 0)
        {
            rb.velocity = rb.velocity * -1;
            bounce--;
            dealtDmg = false;
        }


        if (collision.CompareTag("Enemy"))   
        {
            if (ShootScript.explode == true)
            {
                Instantiate(explode);
            }
        }
    }
}
