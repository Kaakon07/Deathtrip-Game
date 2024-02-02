using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShooterScript : MonoBehaviour
{
    // refrence blah blah blah
    public GameObject bullet;
    public Transform firePoint;

    // lyd som spilelr når du skyter
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
    public int shots = 1;
    public bool explode = false;

 


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        // Finner mus koordinatene, og gjør det om til x y z koordinater i spill omerådet
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Definerer verdien av "lookDircetion" ved å trekke fra spiller posisjonen fra spiller posisjonen
        lookDirection = mousePosition - transform.position;
        // finner vinkelen fra musen til spilleren
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // får firePoint objektet til å rotere mot musen
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        
        


    }
    private void FixedUpdate()
    {
        Fire();
    }

    private void Fire()
    {

        
        int spread = 8; //spread = (int)( 10/(Mathf.Abs(shots) + 1) ) + 5
        // hvor ofte bilen skyter
        if (timer < FireSpeed)
        {
            // teller opp, når den er lik angrepshastigheten skyter den
            timer += 1;
        }
        else
        {
            // lager en kopi av "Bullet" prefabben, så setter start posisjonen og rotasjonen
            for (int i = 0; i < shots; i++)
            {
                // Calculate spread angle
                float angle = (i - (shots / 2)) * spread;

                // Calculate direction towards the mouse
                Vector2 directionToMouse = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)firePoint.position;
                directionToMouse.Normalize();

                // Apply spread to the direction
                float spreadAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg + angle;
                Vector2 newDirection = new Vector2(Mathf.Cos(spreadAngle * Mathf.Deg2Rad), Mathf.Sin(spreadAngle * Mathf.Deg2Rad));

                // Calculate rotation based on the calculated direction
                float rotation = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, rotation);

                // Instantiate bullet and set rotation and velocity based on the calculated direction
                GameObject bulletClone = Instantiate(bullet, firePoint.transform.position, bulletRotation);
                aSource.PlayOneShot(shootSound);
                bulletClone.GetComponent<Rigidbody2D>().velocity = BulletSpeed * newDirection * Time.deltaTime;
                bulletClone.GetComponent<BulletScript>().isRocket = explode;
            }


            timer = 0;
        }
                
                
            
            

            

        
    }
}
