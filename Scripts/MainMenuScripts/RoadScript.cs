using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector3(0,-500,0));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -50)
        {
            Destroy(gameObject);
        }
    }
}
