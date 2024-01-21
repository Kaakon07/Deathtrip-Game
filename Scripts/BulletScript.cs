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



    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, range);
    }
}
