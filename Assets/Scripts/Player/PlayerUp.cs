using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUp : MonoBehaviour
{
    public float jumpForce = 10f;   // The force with which the player jumps

    Rigidbody2D rb;   // Reference to the player's rigidbody component

    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the up arrow key is being pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Apply the jump force in the upwards direction
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
