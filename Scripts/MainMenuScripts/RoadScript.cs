using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    // stats, of referanse till Rigidbodien
    public float Speed = 250;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        // får objektet til å bevege seg nedover
        rb.AddForce(new Vector3(0,(Speed * -1),0));
    }

    // Update is called once per frame
    void Update()
    {
        // sletter objektet når det er under -30 Y
        if (transform.position.y > 30)
        {
            Destroy(gameObject);
        }
    }
}
