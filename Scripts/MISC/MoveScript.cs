
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    // referanse
    public ValueScript script;

    // Variabler for vilken direksjon p� keyboardet ditt du trykker
    public float horizontal;
    public float vertical;

    // Bevegles hastighet og en referance til objektets rigidbody
    public float MoveSpeed;
    public Rigidbody2D rb;
    public Vector3 previousPlayerPosition;

    public float acceleration;
    public float deceleration;

    // Update is called once per frame
    void Update()
    {
        // Definerer direksjon variablene
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        MoveSpeed = script.moveSpeed;
    }

    private void FixedUpdate()
    {
        previousPlayerPosition = rb.position; // Saves the player position before the velocity updates, this is important for chunks loading

        Vector2 movement = new Vector2(horizontal, vertical); // Definerer en Vector2 Variabel som heter movement, og den har axene du skal bevege deg i, fra -1 til 1

        //rb.velocity = movement * MoveSpeed; // Bestemmer hastigheten du beverger deg i, og direksjonen ved � gange axis inputene med bevegelses hastigheten.
        rb.velocity += movement * MoveSpeed*MoveSpeed * acceleration*0.02f;
        rb.velocity -= rb.velocity * MoveSpeed * deceleration * 0.02f;

        if (movement != Vector2.zero) // bestemmer hvordan bil spriten skal rotere seg basert p� veien du kj�rer
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            rb.rotation = angle-90;
        }
    }
}
 