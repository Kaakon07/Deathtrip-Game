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
        Vector2 movement = new Vector2(horizontal, vertical);
        rb.velocity = movement * MoveSpeed;
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            float roundedAngle = Mathf.Round(angle / 45f) * 45f;
            rb.rotation = roundedAngle-90;
        }
    }
}
