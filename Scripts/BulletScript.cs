using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject Player;
    private ShooterScript ShootScript;
    public float Damage;
    public float range;
    public int pierce;
    public int bounce;
    public bool dealtDmg = false;


    // Start is called before the first frame update
    void Start()
    {
        ShootScript = Player.GetComponent<ShooterScript>();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, range);
    }
}
