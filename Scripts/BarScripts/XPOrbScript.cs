using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class XPOrbScript : MonoBehaviour
{
    // referanser
    private ValueScript ValueScript;
    private GameObject Player;
    private Collider2D orbCollider;
    private Collider2D playerCollider;
    private AudioSource playerAudioSource;
    public AudioClip xpPickup;
    public GameObject xpOrbNext;

    // Private variables
    private float xpDistance;

    // Public variables
    public float autoRange = 10f; // hvor nerme den begynner å følge etter deg
    public float xpAmount;
    public int orbType;
    public int orbID;



    void Start()
    {
        // definerer referansene, fordi det er en prefab
        Player = GameObject.Find("Player");
        playerAudioSource = Player.GetComponent<AudioSource>();
        ValueScript = Player.GetComponent<ValueScript>();
        playerCollider = Player.GetComponent<Collider2D>();
        orbCollider = GetComponent<Collider2D>();
    }



    void Update()
    {
        xpDistance = Vector3.Distance(Player.transform.position, transform.position);
        xpDistance = xpDistance * 0.25f;
        xpDistance = 1 - 1 / (Mathf.Abs(xpDistance) + 1);
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, (1-xpDistance*xpDistance) * 5 * Time.deltaTime);

        // hvis den rører spilleren, gir den XP
        if (orbCollider.IsTouching(playerCollider))
        {
            ValueScript.GiveXp(xpAmount);
            playerAudioSource.PlayOneShot(xpPickup, 0.5f);
            Destroy(gameObject);
        }
    }



    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Orb collision");
    //
    //    GameObject collidedObject = collision.collider.gameObject;
    //
    //    XPOrbScript xpScript = collidedObject.GetComponent<XPOrbScript>();
    //    if (xpScript != null)
    //    {
    //        Debug.Log("2 Orbs collided");
    //        if (xpScript.orbType == orbType)
    //        {
    //            Debug.Log("Orbs merged");
    //            Instantiate(xpOrbNext, transform.position, transform.rotation);
    //            Destroy(collidedObject);
    //            //isMerged = true;
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
