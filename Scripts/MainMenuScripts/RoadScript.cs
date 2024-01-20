using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public float Speed = 250;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector3(0,(Speed * -1),0));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }
}
