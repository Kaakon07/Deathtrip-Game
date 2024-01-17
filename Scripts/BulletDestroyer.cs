using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private Transform playerTransform;
    private GameObject Player;
    private Transform bulletTransform;
    private Vector2 distanceVec;
    private float distance;
    private ShooterScript ShootScript;
    public float Damage = 10f;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerTransform = Player.transform;
        bulletTransform = transform;
        ShootScript = Player.GetComponent<ShooterScript>();

        

    }

    // Update is called once per frame
    void Update()
    {
        
        distanceVec = bulletTransform.position - playerTransform.position;
        distance = distanceVec.magnitude;

        if (distance > 50f)
        {
            Destroy(gameObject);
        }
    }
}
