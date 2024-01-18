using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    Vector2 lookDirection;
    float lookAngle;
    private float timer;
    public float FireSpeed = 10f;
    public float BulletSpeed = 50f;
    private int screenHeight;
    private int screenWidth;
    private Vector3 screenRes;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        screenRes = new Vector3(screenWidth, screenHeight, 0);

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        


    }
    private void FixedUpdate()
    {
        if (timer < FireSpeed)
        {
            timer += 1;
        }
        else
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle-90);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * BulletSpeed;
            timer = 0;
        }
    }
}
