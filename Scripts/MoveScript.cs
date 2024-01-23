
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    // referanse
    public ValueScript script;

    // Variabler for vilken direksjon på keyboardet ditt du trykker
    float horizontal;
    float vertical;

    // Bevegles hastighet og en referance til objektets rigidbody
    public float MoveSpeed;
    public Rigidbody2D rb;

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
        // Definerer en Vector2 Variabel som heter movement, og den har axene du skal bevege deg i, fra -1 til 1
        Vector2 movement = new Vector2(horizontal, vertical);
        // Bestemmer hastigheten du beverger deg i, og direksjonen ved å gange axis inputene med bevegelses hastigheten.
        rb.velocity = movement * MoveSpeed;

        // bestemmer hvordan bil spriten skal rotere seg basert på veien du kjører
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            float roundedAngle = Mathf.Round(angle / 45f) * 45f;
            rb.rotation = roundedAngle-90;
        }
    }
}
