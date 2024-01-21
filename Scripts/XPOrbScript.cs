using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrbScript : MonoBehaviour
{
    // referanser
    private ValueScript ValueScript;
    private GameObject Player;
    private Collider2D orbCollider;
    private Collider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        // definerer referansene, fordi det er en prefab
        Player = GameObject.Find("Player");
        ValueScript = Player.GetComponent<ValueScript>();
        playerCollider = Player.GetComponent<Collider2D>();
        orbCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // hvis den rører spilleren, gir den XP
        if (orbCollider.IsTouching(playerCollider))
        {
            ValueScript.GiveXp(20);
            Destroy(gameObject);
        }
    }
}
