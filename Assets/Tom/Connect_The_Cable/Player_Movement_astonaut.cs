using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_astonaut : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public float jumpForce = 7f; // Jump force
    public bool isGrounded; // To check if the player is grounded
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input (left/right)
        float moveInput = Input.GetAxis("Horizontal");

        // Move the player left or right
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check if the player is on the ground and the jump button (space) is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump forces
        }
    }

    // Check if the player is on the ground using OnCollisionEnter2D and OnCollisionExit2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
