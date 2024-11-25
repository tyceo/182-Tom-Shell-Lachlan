using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player_Movement : MonoBehaviour
{
    public float speed = 10f; // Speed of the ship
    public float tiltAngle = 10f; // Maximum tilt angle
    public float tiltSpeed = 15f; // Tilt speed
    public float acceleration = 5f; // Forward acceleration speed
    private Vector2 velocity; // Current velocity of the ship
    private Rigidbody2D rb;
    public int health = 3;

    //black hole
    


    void start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 3;
    }

    private void Update()
    {

        // Handle movement input
        HandleMovement();
        // Check for wall collisions
        CheckBoundaries();
        if (Input.GetKey("escape"))
        {
            Application.Quit();

        }
        if (health <= 0)
        {
            Application.Quit();
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock") && Time.time < 25f)
        {
            health = health - 1;
            Application.Quit();
            print(health);
        }
        if (collision.gameObject.CompareTag("BlackHole") && Time.time < 25f)
        {
            health = health - 3;
            Application.Quit();
            print(health);
        }

    }

    private void HandleMovement()
    {
        // thrust forwards into space
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {

            velocity += (Vector2)(transform.up * acceleration * Time.deltaTime);
        }

        // Move the ship based on its current velocity
        transform.position += (Vector3)velocity * Time.deltaTime;

        // turning
        float tiltInput = Input.GetAxis("Horizontal"); // -1 for a 1 for d i think
        float tilt = tiltInput * tiltAngle;

        // Apply rotation
        transform.Rotate(0, 0, -tilt * tiltSpeed * Time.deltaTime);
    }

    private void CheckBoundaries()
    {
        // Get the screen boundaries
        Vector3 position = transform.position;

        // Teleport to the opposite side if out of bounds
        if (position.x < -Camera.main.orthographicSize * Camera.main.aspect)
        {
            position.x = Camera.main.orthographicSize * Camera.main.aspect;
        }
        else if (position.x > Camera.main.orthographicSize * Camera.main.aspect)
        {
            position.x = -Camera.main.orthographicSize * Camera.main.aspect;
        }

        if (position.y < -Camera.main.orthographicSize)
        {
            position.y = Camera.main.orthographicSize;
        }
        else if (position.y > Camera.main.orthographicSize)
        {
            position.y = -Camera.main.orthographicSize;
        }

        transform.position = position;
    }
}

