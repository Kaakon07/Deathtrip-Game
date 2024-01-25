using System.Collections;
using System.Collections.Generic;
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

    // Private variables
    private float xpDistance;

    // hvor nerme den begynner å følge etter deg
    public float autoRange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // definerer referansene, fordi det er en prefab
        Player = GameObject.Find("Player");
        playerAudioSource = Player.GetComponent<AudioSource>();
        ValueScript = Player.GetComponent<ValueScript>();
        playerCollider = Player.GetComponent<Collider2D>();
        orbCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xpDistance = Vector3.Distance(Player.transform.position, transform.position);
        xpDistance = xpDistance * 0.125f;
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Mathf.Exp(-xpDistance*xpDistance) * 5 * Time.deltaTime);

        // hvis den rører spilleren, gir den XP
        if (orbCollider.IsTouching(playerCollider))
        {
            ValueScript.GiveXp(20);
            playerAudioSource.PlayOneShot(xpPickup, 0.5f);
            Destroy(gameObject);
        }
    }
}
