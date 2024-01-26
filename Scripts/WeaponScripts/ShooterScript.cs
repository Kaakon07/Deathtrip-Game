using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShooterScript : MonoBehaviour
{
    // refrence blah blah blah
    public GameObject bullet;
    public Transform firePoint;

    // lyd som spilelr n�r du skyter
    public AudioClip shootSound;
    public AudioSource aSource;

    // Hvor du ser, og angle av hvor du ser fra spilleren
    Vector3 lookDirection;
    float lookAngle;

    // timer
    private float timer;

    // stats
    public float FireSpeed = 10f;
    public float BulletSpeed = 750f;
    public float Damage = 20;
    public float range = 2;
    public int pierce = 0;
    public int bounce = 0;

 


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        // Finner mus koordinatene, og gj�r det om til x y z koordinater i spill omer�det
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Definerer verdien av "lookDircetion" ved � trekke fra spiller posisjonen fra spiller posisjonen
        lookDirection = mousePosition - transform.position;
        // finner vinkelen fra musen til spilleren
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // f�r firePoint objektet til � rotere mot musen
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        
        


    }
    private void FixedUpdate()
    {
        // hvor ofte bilen skyter
        if (timer < FireSpeed)
        {
            // teller opp, n�r den er lik angrepshastigheten skyter den
            timer += 1;
        }
        else
        {
            // lager en kopi av "Bullet" prefabben, s� setter start posisjonen og rotasjonen
            GameObject bulletClone = Instantiate(bullet);
            aSource.PlayOneShot(shootSound);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle-90);

            // F�r skuddet til � dra fremmover
            bulletClone.GetComponent<Rigidbody2D>().velocity = BulletSpeed * Time.deltaTime * firePoint.right;
            timer = 0;
        }
    }
}
