using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrbScript : MonoBehaviour
{
    private ValueScript ValueScript;
    private GameObject Player;
    private Collider2D orbCollider;
    private Collider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        ValueScript = Player.GetComponent<ValueScript>();
        playerCollider = Player.GetComponent<Collider2D>();
        orbCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (orbCollider.IsTouching(playerCollider))
        {
            ValueScript.GiveXp(20);
            Destroy(gameObject);
        }
    }
}
