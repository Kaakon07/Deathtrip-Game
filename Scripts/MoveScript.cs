using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    float horizontal;
    float vertical;

    public float MoveSpeed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");    
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * MoveSpeed, vertical * MoveSpeed);
    }
}
