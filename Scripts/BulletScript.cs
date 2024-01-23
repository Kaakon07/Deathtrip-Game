using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // referanser til spiller objektet og skyte skripten
    private GameObject Player;
    private ShooterScript ShootScript;

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
        Damage = ShootScript.Damage;
        range = ShootScript.range;
        pierce = ShootScript.pierce;
        bounce = ShootScript.bounce;

    }

    // Update is called once per frame
    void Update()
    {
        Damage = ShootScript.Damage;    
        range = ShootScript.range;
        pierce = ShootScript.pierce;
        bounce = ShootScript.bounce;
        Destroy(gameObject, range);
    }
}
