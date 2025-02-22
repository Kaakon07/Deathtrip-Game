using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool isRocket;


    //Sprites
    public SpriteRenderer spriteRenderer;
    public Sprite spriteBullet;
    public Sprite spriteRocket;


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

        if (isRocket)
        {
            spriteRenderer.sprite = spriteRocket;
        }
        else
        {
            spriteRenderer.sprite = spriteBullet;
        }

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
            if (bulletPos.x < playerPos.x - 29.972222f | bulletPos.x > playerPos.x + 29.972222f) //30.222222 x 17
            {
                Debug.Log("bullet has hit the wall");
                rb.velocity = new Vector2(0 - rb.velocity.x, rb.velocity.y);
                rb.rotation = Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.y, rb.velocity.x);
                bounce--;
                dealtDmg = false;
            }
            if (bulletPos.y < playerPos.y - 16.75 | bulletPos.y > playerPos.y + 16.75)
            {
                Debug.Log("bullet has hit the wall");
                rb.velocity = new Vector2(rb.velocity.x, 0 - rb.velocity.y);
                rb.rotation = Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.y, rb.velocity.x);
                bounce--;
                dealtDmg = false;
            }
        }
    }

    public void Explode(Vector2 pos, Quaternion rot)
    {
       
       Instantiate(explode, pos, rot);
       Debug.Log("Explode");
        
    }
}
